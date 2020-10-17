using DoYou.Domain.Commands.Empresa.CadastrarEmpresa;
using DoYou.Domain.Commands.Empresa.RetornaEmpresaUsuario;
using DoYou.Domain.Commands.Empresa.RetornarEmpresas;
using DoYou.Domain.Commands.Proprietario.AutenticarProprietario;
using DoYou.Domain.Enums;
using DoYou.Domain.Interfaces.Transactions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Api.Controllers
{
    public class EmpresaController : Base.ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmpresaController(IMediator mediator, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }


        [Authorize]
        [HttpPost]
        [Route("api/Empresa/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] CadastrarEmpresaRequest request)
        {
            try
            {
                string proprietarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Proprietario").Value;
                AutenticarProprietarioResponse proprietarioResponse = JsonConvert.DeserializeObject<AutenticarProprietarioResponse>(proprietarioClaims);
                request.FkProprietario = proprietarioResponse.Id;

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
        [Route("api/Empresa/Listar")]
        public async Task<IActionResult> GetEmpresas([FromQuery] RetornarEmpresasRequest request, [FromQuery] EnumCategoria categoria)
        {
            try
            {
                request.Categoria = categoria;
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
        [Route("api/Empresa/Detalhe/{id}")]
        public async Task<IActionResult> GetEmpresaDetalhe(string id)
        {
            try
            {
                RetornaEmpresaUsuarioRequest request = new RetornaEmpresaUsuarioRequest();
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
