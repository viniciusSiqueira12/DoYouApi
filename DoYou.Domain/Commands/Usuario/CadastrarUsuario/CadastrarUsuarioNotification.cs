using MediatR;

namespace DoYou.Domain.Commands.Usuario.CadastrarUsuario
{
    class CadastrarUsuarioNotification : INotification
    {
        public CadastrarUsuarioNotification(Entities.Usuario usuario)
        {
            Usuario = usuario;
        }

        public Entities.Usuario Usuario { get; set; }
    }
}
