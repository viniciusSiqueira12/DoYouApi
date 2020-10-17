using DoYou.Domain.Entities;
using DoYou.Domain.Interfaces.Repositories;
using DoYou.Infra.Repositories.Base;
using System;

namespace DoYou.Infra.Repositories
{
    public class RepositoryMesa : RepositoryBase<Mesa, Guid>, IRepositoryMesa
    {
        private readonly DoYouContext _context;
        public RepositoryMesa(DoYouContext context) : base(context)
        {
            _context = context;
        }
    }
}
