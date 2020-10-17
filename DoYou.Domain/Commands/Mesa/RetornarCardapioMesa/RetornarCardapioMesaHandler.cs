using DoYou.Domain.Entities.Base;
using DoYou.Domain.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Domain.Commands.Mesa.RetornarCardapioMesa
{

    public class RetornarCardapioMesaHandler : Notifiable, IRequestHandler<RetornarCardapioMesaRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryItem _repositoryItem;
        private readonly IRepositoryMesa _repositoryMesa;
        private readonly IRepositoryEmpresa _repositoryEmpresa;
        public RetornarCardapioMesaHandler(IMediator mediator, IRepositoryItem repositoryItem, IRepositoryMesa repositoryMesa, IRepositoryEmpresa repositoryEmpresa)
        {
            _mediator = mediator;
            _repositoryItem = repositoryItem;
            _repositoryMesa = repositoryMesa;
            _repositoryEmpresa = repositoryEmpresa;
        }

        public async Task<Response> Handle(RetornarCardapioMesaRequest request, CancellationToken cancellationToken)
        {
            var mesa = _repositoryMesa.ObterPorId(request.FkMesa.Value);
            var empresa = _repositoryEmpresa.ObterPor(x => x.Mesas.Contains(mesa));
            
            DataTableResponseBase<Entities.Item> Itens = _repositoryItem.CardapioMesaDataTable(request, empresa.Id, request.Tipo);
            RetornarCardapioMesaResponse response = new RetornarCardapioMesaResponse(Itens, empresa, mesa);
            if (Itens != null)
            {
                Response respo = new Response(this, response);
                return await Task.FromResult(respo);
            }
            else
            {
                this.AddNotification("Listar Cardápio", "Erro ao Listar cardápio");
            }
            Response resp = new Response(this);
            return await Task.FromResult(resp);
        }
    }
}
