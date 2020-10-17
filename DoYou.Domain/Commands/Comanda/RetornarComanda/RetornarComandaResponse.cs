using DoYou.Domain.Entities.Base;
using DoYou.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoYou.Domain.Commands.Comanda.RetornarComanda
{
    public class RetornarComandaResponse
   {
        public RetornarComandaResponse(Entities.Comanda comanda)
        {
            Status = comanda.Status;
            Total = comanda.Total;
            DataAbertura = comanda.Abertura;
            Empresa = new EmpresaHelper(comanda.Mesa.Empresa);
            Mesa = new MesaHelper(comanda.Mesa); 
            ItensComanda = comanda.ItensComanda.Select(c => new ItemComandaHelper(c)).ToList();
        }

        public EnumStatusComanda Status { get; set; }
        public double Total { get; set; }
        public DateTime DataAbertura { get; set; }
        public EmpresaHelper Empresa { get; set; }
        public MesaHelper Mesa { get; set; }
        public ICollection<ItemComandaHelper> ItensComanda { get; set; }
    }

    public class EmpresaHelper : EntityBase
    {
        public EmpresaHelper(Entities.Empresa empresa)
        {
            Id = empresa.Id;
            Fantasia = empresa.Fantasia;
            Logo = empresa.Logo;
        }
        public string Fantasia { get; set; }
        public string Logo { get; set; }
    }

    public class MesaHelper : EntityBase
    {
        public MesaHelper(Entities.Mesa mesa)
        {
            Id = mesa.Id;
            Numero = mesa.Numero; 
        }
        public int Numero { get; set; } 
    }

    public class ItemComandaHelper : EntityBase
    { 
        public ItemComandaHelper(Entities.ItemComanda itemComanda)
        { 
            Id = itemComanda.Id;
            Nome = itemComanda.Item.Nome;
            Status = itemComanda.Status;
            Quantidade = itemComanda.Quantidade;
            Foto = itemComanda.Item.Foto;
        }

        
        public string Nome { get; set; }
        public EnumStatusPedido Status { get; set; }
        public int Quantidade { get; set; }
        public double Total { get; set; }
        public string Foto { get; set; }
    }
}
