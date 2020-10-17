using DoYou.Domain.Commands.Item.CadastrarItem;
using DoYou.Domain.Commands.Item.RetornarItensEmpresa;
using DoYou.Domain.Commands.Mesa.RetornarCardapioMesa;
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
    public class ItemController : Base.ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ItemController(IMediator mediator, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }


        [Authorize]
        [HttpPost]
        [Route("api/Item/Adicionar")]
        public async Task<IActionResult> AdicionarItem([FromBody] CadastrarItemRequest request)
        {
            try
            {
                string proprietarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Proprietario").Value;
                AutenticarProprietarioResponse proprietarioResponse = JsonConvert.DeserializeObject<AutenticarProprietarioResponse>(proprietarioClaims);
                request.FkEmpresa = Guid.Parse(proprietarioResponse.EmpresaUltimoAcesso);

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
        [Route("api/Item/Listar/{id}")]
        public async Task<IActionResult> ListarItens([FromQuery] RetornarItensEmpresaRequest request, string id, [FromQuery] EnumTipoItem tipo)
        {
            try
            {
                request.FkEmpresa = Guid.Parse(id);
                request.Tipo = tipo;
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
        [Route("api/Item/Cardapio/{id}")]
        public async Task<IActionResult> GetCardapio([FromQuery] RetornarCardapioMesaRequest request, string id, [FromQuery] EnumTipoItem tipo)
        {
            try
            {
                request.FkMesa = Guid.Parse(id);
                request.Tipo = tipo;
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
