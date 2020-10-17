using DoYou.Domain.Entities.Base;
using System.Linq;

namespace DoYou.Domain.Commands.Item.RetornarItensEmpresa
{
    class RetornarItensEmpresaResponse : DataTableResponseBase<ItemHelper>
    {
        public RetornarItensEmpresaResponse(DataTableResponseBase<Entities.Item> dataTable) :
        base(dataTable.PageSize, dataTable.PageView, dataTable.PageNumber, dataTable.Data.Select(e => new ItemHelper(e)).ToList())
        { }
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
}
