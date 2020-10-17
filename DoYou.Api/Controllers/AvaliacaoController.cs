using DoYou.Domain.commands.Usuario.AutenticarUsuario;
using DoYou.Domain.Commands.Avaliacao.AvaliarRestaurante;
using DoYou.Domain.Commands.Avaliacao.RetornarAvaliacoesEmpresa;
using DoYou.Domain.Interfaces.Transactions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Api.Controllers
{
    public class AvaliacaoController : Base.ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AvaliacaoController(IMediator mediator, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpPost]
        [Route("api/Avaliacao/Avaliar/{id}")]
        public async Task<IActionResult> AvaliarRestaurante([FromBody] AvaliarRestauranteRequest request, string id)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);
                request.FkUsuario = usuarioResponse.Id;
                request.FkEmpresa = Guid.Parse(id);
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/Avaliacao/Avaliacoes/{id}")]
        public async Task<IActionResult> GetAvaliacoesEmpresa([FromQuery] RetornarAvaliacoesEmpresaRequest request, string id)
        {
            try
            {
                request.FkEmpresa = Guid.Parse(id);
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }



}
