using DoYou.Domain.Interfaces.Repositories;
using DoYou.Domain.Interfaces.Transactions;
using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Domain.Commands.Empresa.CadastrarEmpresa
{


    public class CadastrarEmpresaHandler : Notifiable, IRequestHandler<CadastrarEmpresaRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryEmpresa _repositoryEmpresa;
        private readonly IRepositoryProprietario _repositoryProprietario;

        public CadastrarEmpresaHandler(IMediator mediator, IRepositoryEmpresa repositoryEmpresa, IRepositoryProprietario repositoryProprietario, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _repositoryEmpresa = repositoryEmpresa;
            _repositoryProprietario = repositoryProprietario;
            _unitOfWork = unitOfWork;
        }



        public async Task<Response> Handle(CadastrarEmpresaRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Resquest", "Preencha as informações da Empresa");
                return new Response(this);
            }

            if (_repositoryEmpresa.Existe(x => x.Cnpj == request.Cnpj))
            {
                AddNotification("Resquest", "Empresa já está cadastrada");
                return new Response(this);
            }

            var proprietario = _repositoryProprietario.ObterPorId(request.FkProprietario.Value);

            if (proprietario == null)
            {
                AddNotification("Resquest", "O proprietário não é válido");
                return new Response(this);
            }

            Entities.Empresa empresa = new Entities.Empresa(request.RazaoSocial, request.Fantasia, request.Cnpj, request.Email, request.Telefone, request.Categoria, request.Endereco, proprietario);
            if (IsInvalid())
            {
                return new Response(this);
            }
            AddNotifications(empresa);

            empresa = _repositoryEmpresa.Adicionar(empresa);

            proprietario.AdicionarEmpresa(empresa);
            proprietario.EmpresaUltimoAcesso = empresa.Id.ToString();
            _repositoryProprietario.Editar(proprietario);
            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                this.AddNotification("Adicionar Empresa", "Erro ao persistir dados: " + ex.Message);
            }

            var result = new { RazaoSocial = empresa.RazaoSocial, Fantasia = empresa.Fantasia, Cnpj = empresa.Cnpj, Telefone = empresa.Telefone, Proprietario = empresa.Proprietario.Nome };
            var response = new Response(this, result);
            return await Task.FromResult(response);
        }
    }
}
