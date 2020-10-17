using DoYou.Domain.Entities.Base;
using DoYou.Domain.ObjectValues;
using System.Linq;

namespace DoYou.Domain.Commands.Empresa.RetornarEmpresas
{
    public class RetornarEmpresasResponse : DataTableResponseBase<EmpresaHelper>
    {
        public RetornarEmpresasResponse(DataTableResponseBase<Entities.Empresa> dataTable) :
        base(dataTable.PageSize, dataTable.PageView, dataTable.PageNumber, dataTable.Data.Select(e => new EmpresaHelper(e)).ToList())
        { }
    }

    public class EmpresaHelper : EntityBase
    {
        public EmpresaHelper(Entities.Empresa empresa)
        {
            Id = empresa.Id;
            UrlLogo = empresa.Logo;
            Fantasia = empresa.Fantasia;
            Endereco = empresa.Endereco;
            MesasDisponiveis = empresa.Mesas.Where(x => x.Ocupada != true).Count();
            TotalMesas = empresa.Mesas.Count();
        }
        public string Fantasia { get; set; }
        public string UrlLogo { get; set; }
        public Endereco Endereco { get; set; }
        public int MesasDisponiveis { get; set; }
        public int TotalMesas { get; set; }
    }
}
