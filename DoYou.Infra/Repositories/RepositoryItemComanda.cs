using DoYou.Domain.Entities;
using DoYou.Domain.Interfaces.Repositories;
using DoYou.Infra.Repositories.Base;
using System;

namespace DoYou.Infra.Repositories
{
    public class RepositoryItemComanda : RepositoryBase<ItemComanda, Guid>, IRepositoryItemComanda
    {
        private readonly DoYouContext _context;
        public RepositoryItemComanda(DoYouContext context) : base(context)
        {
            _context = context;
        }
    }
}
   