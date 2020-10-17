using DoYou.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DoYou.Domain.Entities
{
    public class Mesa : EntityBase
    {
        protected Mesa()
        {
        }

        public Mesa(int numero, Empresa empresa)
        {
            Numero = numero;
            Empresa = empresa;
        }

        public void AdicionarComanda(Comanda comanda)
        {
            Comandas.Add(comanda);
        }
        public int Numero { get; private set; }
        public bool Ocupada { get; set; }
        public Empresa Empresa { get; private set; }
        public ICollection<Comanda> Comandas { get; private set; } = new Collection<Comanda> { };
        //public ICollection<Pedido> Pedidos { get; set; } = new Collection<Pedido> { };
    }
}
