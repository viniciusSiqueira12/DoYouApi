using MediatR;
using prmToolkit.NotificationPattern;

namespace DoYou.Domain.Commands.Proprietario.CadastrarProprietario
{
    public class CadastrarProprietarioRequest : IRequest<Response>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Celular { get; set; }
    }
}
