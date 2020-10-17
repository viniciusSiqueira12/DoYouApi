using DoYou.Domain.Entities.Base;
using DoYou.Domain.Enums;
using prmToolkit.NotificationPattern;
using System;

namespace DoYou.Domain.Entities
{
    public class ItemComanda : EntityBase
    {
        protected ItemComanda()
        {

        }
        public ItemComanda(EnumStatusPedido status, int quantidade, double valorItem, double total, string observacao, Item item, Comanda comanda)
        {
            Status = status;
            Quantidade = quantidade;
            ValorItem = valorItem;
            Total = total;
            Observacao = observacao;
            Item = item;
            Comanda = comanda;


            DataPedido = DateTime.Now;
        }

        public EnumStatusPedido Status { get; private set; }
        public int Quantidade { get; private set; }
        public double ValorItem { get; private set; }
        public double Total { get; private set; }
        public string Observacao { get; private set; }
        public Item Item { get; private set; }
        public Comanda Comanda { get; private set; }
        public DateTime DataPedido { get; private set; }
    }
}
