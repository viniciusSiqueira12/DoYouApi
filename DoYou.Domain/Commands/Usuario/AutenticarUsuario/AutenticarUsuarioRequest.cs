using MediatR;

namespace DoYou.Domain.commands.Usuario.AutenticarUsuario
{
    public class AutenticarUsuarioRequest : IRequest<AutenticarUsuarioResponse>
    {

        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
