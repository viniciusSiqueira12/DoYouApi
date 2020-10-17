using DoYou.Domain.Commands.Mesa.CadastrarMesa;
using DoYou.Domain.Commands.Proprietario.AutenticarProprietario;
using DoYou.Domain.Interfaces.Transactions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Api.Controllers
{
    public class MesaController : Base.ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MesaController(IMediator mediator, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpPost]
        [Route("api/Mesa/Cadastrar")]
        public async Task<IActionResult> AdicionarMesa([FromBody] CadastrarMesaRequest request)
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
    }
}
