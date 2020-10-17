using MediatR;
using prmToolkit.NotificationPattern;
using System;

namespace DoYou.Domain.Commands.Usuario.CadastrarUsuario
{
    public class CadastrarUsuarioRequest : IRequest<Response>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Celular { get; set; }
        public DateTime DataAniversario { get; set; }
    }
}
