using DoYou.Domain.Entities;
using DoYou.Domain.Interfaces.Repositories;
using DoYou.Infra.Repositories.Base;
using System;

namespace DoYou.Infra.Repositories
{
    public class RespositoryUsuario : RepositoryBase<Usuario, Guid>, IRepositoryUsuario
    {
        private readonly DoYouContext _context;
        public RespositoryUsuario(DoYouContext context) : base(context)
        {
            _context = context;
        }
         
    }
}
