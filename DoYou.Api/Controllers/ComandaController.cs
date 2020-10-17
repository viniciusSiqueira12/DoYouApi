using DoYou.Domain.Commands.Comanda.RetornarComanda;
using DoYou.Domain.Interfaces.Transactions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Api.Controllers
{
    public class ComandaController : Base.ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ComandaController(IMediator mediator, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpGet]
        [Route("api/Comanda/{FkComanda}")]
        public async Task<IActionResult> GetEmpresas(string fkComanda)
        {
            try
            {
                RetornarComandaRequest request = new RetornarComandaRequest();
                request.FkComanda = Guid.Parse(fkComanda);
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
