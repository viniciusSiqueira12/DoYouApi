using MediatR;
using prmToolkit.NotificationPattern;
using System;

namespace DoYou.Domain.Commands.Pedido.RealizarPedido
{
    public class RealizarPedidoRequest : IRequest<Response>
    {
        public Guid? FkMesa { get; set; }
        public Guid? FkUsuario { get; set; }
        public ItemPedidoHelper[] ItemPedido { get; set; }
        public Guid? FkComanda { get; set; }
    }

    public class ItemPedidoHelper
    {
        public Guid? FkItem { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }
    }
}
