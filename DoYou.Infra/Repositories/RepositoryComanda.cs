using DoYou.Domain.Entities;
using DoYou.Domain.Interfaces.Repositories;
using DoYou.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DoYou.Infra.Repositories
{
    public class RepositoryComanda : RepositoryBase<Comanda, Guid>, IRepositoryComanda
    {
        private readonly DoYouContext _context;
        public RepositoryComanda(DoYouContext context) : base(context)
        {
            _context = context;
        }

        public Comanda RetornarComanda(Guid FkComanda)
        {
           return _context.Comanda.Include(x => x.ItensComanda)
                    .ThenInclude(x => x.Item)
                        .Include(x => x.Mesa)
                            .ThenInclude(x => x.Empresa)
             .Where(x => x.Id == FkComanda).FirstOrDefault();
        }
    }
}
