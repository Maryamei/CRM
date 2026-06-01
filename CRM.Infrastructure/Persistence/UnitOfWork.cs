using CRM.Context;
using CRM.Domain.Interfaces;

namespace CRM.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CRMContext _context;

        public UnitOfWork(CRMContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
