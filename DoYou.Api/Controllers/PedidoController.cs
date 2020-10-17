using DoYou.Domain.commands.Usuario.AutenticarUsuario;
using DoYou.Domain.Commands.Pedido.RealizarPedido;
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
    public class PedidoController : Base.ControllerBase
    { 
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PedidoController(IMediator mediator, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }
        [Authorize]
        [HttpPost]
        [Route("api/Pedido/Realizar/{FkMesa}")]
        public async Task<IActionResult> AdicionarMesa([FromBody] RealizarPedidoRequest request, string FkMesa)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);
                request.FkUsuario = usuarioResponse.Id;
                request.FkMesa = Guid.Parse(FkMesa);
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
