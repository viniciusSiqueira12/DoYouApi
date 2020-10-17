using MediatR;
using prmToolkit.NotificationPattern;
using System;

namespace DoYou.Domain.Commands.Comanda.RetornarComanda
{
    public class RetornarComandaRequest : IRequest<Response>
    {
        public Guid? FkComanda { get; set; }
    }
}
