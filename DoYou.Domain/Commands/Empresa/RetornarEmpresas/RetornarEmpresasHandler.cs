using DoYou.Domain.Entities.Base;
using DoYou.Domain.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Domain.Commands.Empresa.RetornarEmpresas
{
    public class RetornarEmpresasHandler : Notifiable, IRequestHandler<RetornarEmpresasRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryEmpresa _repositoryEmpresa;
        private readonly IRepositoryMesa _repositoryMesa;

        public RetornarEmpresasHandler(IMediator mediator, IRepositoryEmpresa repositoryEmpresa, IRepositoryMesa repositoryMesa)
        {
            _mediator = mediator;
            _repositoryEmpresa = repositoryEmpresa;
            _repositoryMesa = repositoryMesa;
        }
        public async Task<Response> Handle(RetornarEmpresasRequest request, CancellationToken cancellationToken)
        {
            DataTableResponseBase<Entities.Empresa> empresas = _repositoryEmpresa.EmpresasDataTable(request, request.Categoria);
            RetornarEmpresasResponse response = new RetornarEmpresasResponse(empresas);
            if (empresas != null)
            {
                Response respo = new Response(this, response);
                return await Task.FromResult(respo);
            }
            else
            {
                this.AddNotification("Listar Empresas", "Erro ao Listar Empresas");
            }
            Response resp = new Response(this);
            return await Task.FromResult(resp);
        }
    }
}
