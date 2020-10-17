using DoYou.Domain.Entities;
using DoYou.Domain.Entities.Base;
using DoYou.Domain.Interfaces.Repositories;
using DoYou.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DoYou.Infra.Repositories
{
    public class RepositoryAvaliacao : RepositoryBase<Avaliacao, Guid>, IRepositoryAvaliacao
    {
        private readonly DoYouContext _context;
        public RepositoryAvaliacao(DoYouContext context) : base(context)
        {
            _context = context;
        }

        public DataTableResponseBase<Avaliacao> AvaliacoesEmpresaDataTable(DataTableBase<Avaliacao> dataTableBase, Guid FkEmpresa)
        {
            {
                var query = _context.Set<Avaliacao>()
                 
                    .Include(x => x.Usuario)
                    .Where(x => x.Empresa.Id == FkEmpresa).AsQueryable();


                int count = query.Count();
                query = query.OrderBy(x => x.DataCriacao);
                query = query.Skip(dataTableBase.PageNumber * dataTableBase.PageView).Take(dataTableBase.PageView);
                DataTableResponseBase<Avaliacao> resp = new DataTableResponseBase<Avaliacao>(count, dataTableBase.PageView, dataTableBase.PageNumber, query.ToList());
                return resp;
            }
        }
    }



}
