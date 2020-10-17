using DoYou.Domain.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Domain.Commands.Proprietario.AutenticarProprietario
{
    public class AutenticarProprietarioHandler : Notifiable, IRequestHandler<AutenticarProprietarioRequest, AutenticarProprietarioResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryProprietario _repositoryProprietario;

        public AutenticarProprietarioHandler(IMediator mediator, IRepositoryProprietario repositoryProprietario)
        {
            _mediator = mediator;
            _repositoryProprietario = repositoryProprietario;
        }

        public async Task<AutenticarProprietarioResponse> Handle(AutenticarProprietarioRequest request, CancellationToken cancellationToken)
        {
            //Valida se o objeto request esta nulo
            if (request == null)
            {
                AddNotification("Request", "Request é obrigatório");
                return null;
            }

            //request.Senha = request.Senha.ConvertToMD5();
             

            Entities.Proprietario proprietario = _repositoryProprietario.ObterPor(x => x.Email == request.Email && x.Senha == request.Senha);

            if (proprietario == null)
            {
                AddNotification("Proprietario", "Usuário não encontrado.");
                return new AutenticarProprietarioResponse()
                {
                    Autenticado = false
                };
            }

            //Cria objeto de resposta
            var response = (AutenticarProprietarioResponse)proprietario;

            ////Retorna o resultado
            return await Task.FromResult(response);
        }
    }
}
