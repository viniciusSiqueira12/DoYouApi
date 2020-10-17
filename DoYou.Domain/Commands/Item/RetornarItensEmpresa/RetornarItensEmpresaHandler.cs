using DoYou.Domain.Entities.Base;
using DoYou.Domain.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Domain.Commands.Item.RetornarItensEmpresa
{

    public class RetornarItensEmpresaHandler : Notifiable, IRequestHandler<RetornarItensEmpresaRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryItem _repositoryItem;
        public RetornarItensEmpresaHandler(IMediator mediator, IRepositoryItem repositoryItem)
        {
            _mediator = mediator;
            _repositoryItem = repositoryItem;
        }

        public async Task<Response> Handle(RetornarItensEmpresaRequest request, CancellationToken cancellationToken)
        {
            DataTableResponseBase<Entities.Item> Itens = _repositoryItem.ItensEmpresaDatatable(request, request.FkEmpresa.Value, request.Tipo);
            RetornarItensEmpresaResponse response = new RetornarItensEmpresaResponse(Itens);
            if (Itens != null)
            {
                Response respo = new Response(this, response);
                return await Task.FromResult(respo);
            }
            else
            {
                this.AddNotification("Listar Empresas", "Erro ao Listar Itens");
            }
            Response resp = new Response(this);
            return await Task.FromResult(resp);
        }
    }
}
