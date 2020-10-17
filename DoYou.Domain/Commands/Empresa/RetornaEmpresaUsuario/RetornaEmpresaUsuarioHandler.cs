using DoYou.Domain.Interfaces.Repositories;
using DoYou.Domain.Interfaces.Transactions;
using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Domain.Commands.Empresa.RetornaEmpresaUsuario
{
    public class RetornaEmpresaUsuarioHandler : Notifiable, IRequestHandler<RetornaEmpresaUsuarioRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryEmpresa _repositoryEmpresa; 

        public RetornaEmpresaUsuarioHandler(IMediator mediator, IRepositoryEmpresa repositoryEmpresa, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _repositoryEmpresa = repositoryEmpresa; 
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(RetornaEmpresaUsuarioRequest request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                AddNotification("Resquest", "Id inválido!");
                return new Response(this);
            }

            Entities.Empresa empresa = _repositoryEmpresa.ObterPorId(request.FkEmpresa.Value);
            if (empresa == null)
            {
                AddNotification("Empresa", "A empresa não existe!");
                return new Response(this);
            }

            Response resp = new Response(this, empresa);
            return await Task.FromResult(resp);

            throw new NotImplementedException();
        }
    }
}
