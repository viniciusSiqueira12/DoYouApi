using DoYou.Domain.Entities;
using DoYou.Domain.Interfaces.Repositories.Base;
using System;

namespace DoYou.Domain.Interfaces.Repositories
{
    public interface IRepositoryComanda : IRepositoryBase<Comanda, Guid>
    {
        public Comanda RetornarComanda(Guid FkComanda);
    }
}
