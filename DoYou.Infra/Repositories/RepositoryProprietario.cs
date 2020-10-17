using DoYou.Domain.Entities;
using DoYou.Domain.Interfaces.Repositories;
using DoYou.Infra.Repositories.Base;
using System;

namespace DoYou.Infra.Repositories
{
    public class RepositoryProprietario : RepositoryBase<Proprietario, Guid>, IRepositoryProprietario
    {
        private readonly DoYouContext _context;
        public RepositoryProprietario(DoYouContext context) : base(context)
        {
            _context = context;
        } 
    }
}
