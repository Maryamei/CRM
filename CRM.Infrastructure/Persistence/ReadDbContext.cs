using CRM.Application.Common.Interfaces;
using CRM.Context;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Persistence
{
    public class ReadDbContext : IReadDbContext
    {
        private readonly CRMContext _context;
        public ReadDbContext(CRMContext context)
        {
            _context = context;
        }
        public IQueryable<Tentity> GetBaseQuery<Tentity>() where Tentity : class
        {
            return _context.Set<Tentity>().AsNoTracking();
        }
    }
}
