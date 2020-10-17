using System;

namespace DoYou.Domain.commands.Usuario.AutenticarUsuario
{
    public class AutenticarUsuarioResponse
    { 
        public bool Autenticado { get; set; }
        public Guid Id { get; set; }
        public Entities.Usuario Usuario { get; set; }

        public static explicit operator AutenticarUsuarioResponse(Entities.Usuario usuario)
        {
            return new AutenticarUsuarioResponse()
            {
                Id = usuario.Id,
                Autenticado = true,
                Usuario = usuario
            };
        }
    }
}
