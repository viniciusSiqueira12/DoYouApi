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
    public class RepositoryItem : RepositoryBase<Item, Guid>, IRepositoryItem
    {
        private readonly DoYouContext _context;
        public RepositoryItem(DoYouContext context) : base(context)
        {
            _context = context;
        }

        public DataTableResponseBase<Item> CardapioMesaDataTable(DataTableBase<Item> dataTableBase, Guid FkEmpresa, EnumTipoItem tipo)
        {
            var query = _context.Set<Item>() 
               .Where(x => x.Empresa.Id == FkEmpresa).AsQueryable();
 

            if (dataTableBase.Filter != null && dataTableBase.Filter != string.Empty)
                query = query.Where(e => e.Nome.Contains(dataTableBase.Filter) || e.Descricao.Contains(dataTableBase.Filter));

            if (tipo.IsEnumValid())
                query = query.Where(x => x.Tipo == tipo);
            //if (tipo.IsEnumValid())
            //    query = query.Where(x => x.Tipo == tipo);

            int count = query.Count();
            query = query.OrderBy(x => x.Nome);
            query = query.Skip(dataTableBase.PageNumber * dataTableBase.PageView).Take(dataTableBase.PageView);
            DataTableResponseBase<Item> resp = new DataTableResponseBase<Item>(count, dataTableBase.PageView, dataTableBase.PageNumber, query.ToList());
            return resp;
        }

        public DataTableResponseBase<Item> ItensEmpresaDatatable(DataTableBase<Item> dataTableBase, Guid FkEmpresa, EnumTipoItem tipo)
        {
            var query = _context.Set<Item>()
                .Where(x => x.Tipo == tipo)
               .Where(x => x.Empresa.Id == FkEmpresa).AsQueryable();

            if (dataTableBase.Filter != null && dataTableBase.Filter != string.Empty)
                query = query.Where(e => e.Nome.Contains(dataTableBase.Filter) || e.Descricao.Contains(dataTableBase.Filter));

            int count = query.Count();
            query = query.OrderBy(x => x.Nome);
            query = query.Skip(dataTableBase.PageNumber * dataTableBase.PageView).Take(dataTableBase.PageView);
            DataTableResponseBase<Item> resp = new DataTableResponseBase<Item>(count, dataTableBase.PageView, dataTableBase.PageNumber, query.ToList());
            return resp;
        }
    }
}
