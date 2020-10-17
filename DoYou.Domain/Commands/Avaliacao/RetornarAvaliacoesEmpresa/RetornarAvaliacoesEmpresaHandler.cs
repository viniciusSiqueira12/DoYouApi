using DoYou.Domain.Entities.Base;
using DoYou.Domain.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Domain.Commands.Avaliacao.RetornarAvaliacoesEmpresa
{
    public class RetornarAvaliacoesEmpresaHandler : Notifiable, IRequestHandler<RetornarAvaliacoesEmpresaRequest, Response>
    {
        private readonly IMediator _mediator;  
        private readonly IRepositoryAvaliacao _repositoryAvaliacao;

        public RetornarAvaliacoesEmpresaHandler(IMediator mediator, IRepositoryAvaliacao repositoryAvaliacao)
        {
            _mediator = mediator; 
            _repositoryAvaliacao = repositoryAvaliacao; 
        }

        public async Task<Response> Handle(RetornarAvaliacoesEmpresaRequest request, CancellationToken cancellationToken)
        {
            DataTableResponseBase<Entities.Avaliacao> avaliacoes = _repositoryAvaliacao.AvaliacoesEmpresaDataTable(request, request.FkEmpresa.Value);
            RetornarAvaliacoesEmpresaResponse response = new RetornarAvaliacoesEmpresaResponse(avaliacoes);
            if (avaliacoes != null)
            {
                Response respo = new Response(this, response);
                return await Task.FromResult(respo);
            }
            else
            {
                this.AddNotification("Listar Avaliações", "Erro ao Listar Avaliaões");
            }
            Response resp = new Response(this);
            return await Task.FromResult(resp);
        }
    }
}
