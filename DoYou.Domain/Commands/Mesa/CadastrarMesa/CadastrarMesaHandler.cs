using DoYou.Domain.Interfaces.Repositories;
using DoYou.Domain.Interfaces.Transactions;
using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Domain.Commands.Mesa.CadastrarMesa
{
    public class CadastrarMesaHandler : Notifiable, IRequestHandler<CadastrarMesaRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryMesa _repositoryMesa;
        private readonly IRepositoryProprietario _repositoryProprietario;
        private readonly IRepositoryEmpresa _repositoryEmpresa;
        private readonly IUnitOfWork _unitOfWork;

        public CadastrarMesaHandler(IMediator mediator, IRepositoryMesa repositoryMesa, IRepositoryProprietario repositoryProprietario, IRepositoryEmpresa repositoryEmpresa, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _repositoryMesa = repositoryMesa;
            _repositoryProprietario = repositoryProprietario;
            _repositoryEmpresa = repositoryEmpresa;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(CadastrarMesaRequest request, CancellationToken cancellationToken)
        {
            //Validar se o requeste veio preenchido
            if (request == null)
            {
                AddNotification("Resquest", "Preencha as informações da mesa");
                return new Response(this);
            }


            var proprietario = _repositoryProprietario.ObterPorId(request.FkProprietario.Value);
            var empresa = _repositoryEmpresa.ObterPorId(Guid.Parse(proprietario.EmpresaUltimoAcesso));

            var contains = empresa.Mesas.Where(x => x.Numero == request.Numero);
            if (contains == null)
            {
                AddNotification("Mesa", "A mesa já foi cadastrada");
                return new Response(this);
            }

            Entities.Mesa mesa = new Entities.Mesa(request.Numero, empresa);

            if(IsInvalid())
            {
                return new Response(this);
            }
            AddNotifications(mesa);
            mesa = _repositoryMesa.Adicionar(mesa);

            empresa.AdicionarMesa(mesa);
            _repositoryEmpresa.Editar(empresa);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                this.AddNotification("Adicionar Empresa", "Erro ao persistir dados: " + ex.Message);
            }
            if (IsInvalid())
            {
                return new Response(this);
            }

            var result = new { Id = mesa.Id, Nome = mesa.Numero, Empresa = mesa.Empresa.Fantasia };
            var response = new Response(this, result);
            return await Task.FromResult(response);


        }

    }
}
