using DoYou.Domain.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Domain.Commands.Proprietario.CadastrarProprietario
{


    public class CadastrarProprietarioHandler : Notifiable, IRequestHandler<CadastrarProprietarioRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryProprietario _repositoryProprietario;

        public CadastrarProprietarioHandler(IMediator mediator, IRepositoryProprietario repositoryProprietario)
        {
            _mediator = mediator;
            _repositoryProprietario = repositoryProprietario;
        }

        public async Task<Response> Handle(CadastrarProprietarioRequest request, CancellationToken cancellationToken)
        {
            if (_repositoryProprietario.Existe(x => x.Email == request.Email))
            {
                AddNotification("Email", "O email já está cadastrado");
                return new Response(this);
            }

            Entities.Proprietario proprietario = new Entities.Proprietario(request.Nome, request.Email, request.Senha, request.Celular);
            if (IsInvalid())
            {
                return new Response(this);
            }
            proprietario = _repositoryProprietario.Adicionar(proprietario);
            var response = new Response(this, proprietario);
            return await Task.FromResult(response);

            //AdicionarUsuarioNotification adicionarUsuarioNotification = new AdicionarUsuarioNotification(usuario); 
            //await _mediator.Publish(adicionarUsuarioNotification);


        }
    }
}
