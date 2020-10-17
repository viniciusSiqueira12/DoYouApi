using DoYou.Domain.Entities.Base;
using System.Linq;

namespace DoYou.Domain.Commands.Mesa.RetornarCardapioMesa
{

    class RetornarCardapioMesaResponse : DataTableResponseBase<ItemHelper>
    {
        public RetornarCardapioMesaResponse(DataTableResponseBase<Entities.Item> dataTable, Entities.Empresa empresa, Entities.Mesa mesa) :
        base(dataTable.PageSize, dataTable.PageView, dataTable.PageNumber, dataTable.Data.Select(e => new ItemHelper(e)).ToList())
        {
            this.Empresa = new EmpresaHelper(empresa);
            this.Mesa = new MesaHelper(mesa);
        }

        public EmpresaHelper Empresa { get; set; }
        public MesaHelper Mesa { get; set; }
    }

    public class ItemHelper : EntityBase
    {
        public ItemHelper(Entities.Item item)
        {
            Id = item.Id;
            Nome = item.Nome;
            Descricao = item.Descricao;
            UrlFoto = item.Foto;
            Valor = item.Valor;
        }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string UrlFoto { get; set; }
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
}
