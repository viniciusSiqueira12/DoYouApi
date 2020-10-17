using DoYou.Api.Security;
using DoYou.Domain.Commands.Proprietario.AutenticarProprietario;
using DoYou.Domain.Commands.Proprietario.CadastrarProprietario;
using DoYou.Domain.Interfaces.Transactions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Api.Controllers
{
    public class ProprietarioController : Base.ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProprietarioController(IMediator mediator, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("api/Proprietario/Cadastrar")]
        public async Task<IActionResult> CadastrarProprietario([FromBody] CadastrarProprietarioRequest request)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }

            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("api/Proprietario/Autenticar")]
        public async Task<IActionResult> Autenticar(
        [FromBody] AutenticarProprietarioRequest request,
        [FromServices] SigningConfigurations signingConfigurations,
        [FromServices] TokenConfigurations tokenConfigurations)
        {

            try
            {
                var autenticarProprietarioResponse = await _mediator.Send(request, CancellationToken.None);

                if (autenticarProprietarioResponse.Autenticado == true)
                {
                    var response = GerarToken(autenticarProprietarioResponse, signingConfigurations, tokenConfigurations);

                    return Ok(response);
                }

                return Ok(autenticarProprietarioResponse);

            }
            catch (System.Exception ex)
            {

                return NotFound(ex.Message);
            }
        }


        private object GerarToken(AutenticarProprietarioResponse response, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
        {
            if (response.Autenticado == true)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(response.Id.ToString(), "Id"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        //new Claim(JwtRegisteredClaimNames.UniqueName, response.Proprietario)
                        new Claim("Proprietario", JsonConvert.SerializeObject(response))
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK",
                    PrimeiroNome = response.Nome
                };
            }
            else
            {
                return response;
            }
        }

    }
}
