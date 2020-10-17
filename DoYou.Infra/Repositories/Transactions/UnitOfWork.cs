using DoYou.Domain.Interfaces.Transactions;
using DoYou.Infra.Repositories.Base;

namespace DoYou.Infra.Repositories.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DoYouContext _context;

        public UnitOfWork(DoYouContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
