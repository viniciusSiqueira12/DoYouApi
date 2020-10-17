using MediatR;

namespace DoYou.Domain.Commands.Proprietario.AutenticarProprietario
{
    public class AutenticarProprietarioRequest : IRequest<AutenticarProprietarioResponse>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
