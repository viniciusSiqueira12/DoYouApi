using DoYou.Domain.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Domain.Commands.Usuario.CadastrarUsuario
{
    public class CadastrarUsuarioHandler : Notifiable, IRequestHandler<CadastrarUsuarioRequest, Response>
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IMediator _mediator;

        public CadastrarUsuarioHandler(IRepositoryUsuario repositoryUsuario, IMediator mediator)
        {
            _repositoryUsuario = repositoryUsuario;
            _mediator = mediator;
        }

        public async Task<Response> Handle(CadastrarUsuarioRequest request, CancellationToken cancellationToken)
        {
            if (_repositoryUsuario.Existe(x => x.Email == request.Email))
            {
                AddNotification("Email", "O email já está cadastrado");
                return new Response(this);
            }

            Entities.Usuario usuario = new Entities.Usuario(request.Nome, request.Email, request.Senha, request.Celular, request.DataAniversario);
            if (IsInvalid())
            {
                return new Response(this);
            }

            AddNotifications(usuario);
            usuario = _repositoryUsuario.Adicionar(usuario);
            var response = new Response(this, usuario);
            CadastrarUsuarioNotification cadastrarUsuarioNotification = new CadastrarUsuarioNotification(usuario);
            await _mediator.Publish(cadastrarUsuarioNotification);
            return await Task.FromResult(response);
        }
    }
}
