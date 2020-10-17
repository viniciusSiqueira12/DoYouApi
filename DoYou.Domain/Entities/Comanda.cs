using DoYou.Domain.Entities.Base;
using DoYou.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DoYou.Domain.Entities
{
    public class Comanda : EntityBase
    {
        protected Comanda()
        {

        }
        public Comanda(Usuario usuario, Mesa mesa)
        {
            Usuario = usuario;
            Mesa = mesa;
            Status = EnumStatusComanda.EmAberto;
            Abertura = DateTime.Now;
        }
          
        public void AdicionarItensComanda(ItemComanda itemComanda)
        {
            ItensComanda.Add(itemComanda);
        }
        public EnumStatusComanda Status { get; set; }
        public DateTime Abertura  { get; set; }
        public DateTime Fechada { get; private set; }
        public double Total { get; set; }
        public double SubTotal { get; private set; }
        public int Gorjeta { get; private set; }
        public Usuario Usuario { get; private set; }
        public Mesa Mesa { get; private set; }
        public ICollection<ItemComanda> ItensComanda { get; private set; } = new Collection<ItemComanda> { };
    }
}
