using MediatR;
using prmToolkit.NotificationPattern;
using System;

namespace DoYou.Domain.Commands.Mesa.CadastrarMesa
{
    public class CadastrarMesaRequest : IRequest<Response>
    {
        public int Numero { get; set; }
        public Guid? FkProprietario { get; set; }
    }
}
