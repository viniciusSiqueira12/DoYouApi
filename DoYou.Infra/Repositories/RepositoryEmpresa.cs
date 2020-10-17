using DoYou.Domain.Entities;
using DoYou.Domain.Entities.Base;
using DoYou.Domain.Enums;
using DoYou.Domain.Interfaces.Repositories;
using DoYou.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Linq;

namespace DoYou.Infra.Repositories
{

    public class RepositoryEmpresa : RepositoryBase<Empresa, Guid>, IRepositoryEmpresa
    {
        private readonly DoYouContext _context;
        public RepositoryEmpresa(DoYouContext context) : base(context)
        {
            _context = context;
        }

        public DataTableResponseBase<Empresa> EmpresasDataTable(DataTableBase<Empresa> dataTableBase, EnumCategoria categoria)
        {
            var query = _context.Set<Empresa>()
                .Include(x => x.Mesas)
                .Where(x => x.Ativo == true).AsQueryable();

            if (dataTableBase.Filter != null && dataTableBase.Filter != string.Empty)
                query = query.Where(e => e.Fantasia.Contains(dataTableBase.Filter) || e.RazaoSocial.Contains(dataTableBase.Filter));

            if (categoria.IsEnumValid())
                query = query.Where(x => x.Categoria == categoria);

            int count = query.Count();
            query = query.OrderBy(x => x.DataCadastro);
            query = query.Skip(dataTableBase.PageNumber * dataTableBase.PageView).Take(dataTableBase.PageView);
            DataTableResponseBase<Empresa> resp = new DataTableResponseBase<Empresa>(count, dataTableBase.PageView, dataTableBase.PageNumber, query.ToList());
            return resp;
        }
    }
}
