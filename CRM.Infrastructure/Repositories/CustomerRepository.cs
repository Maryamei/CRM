using CRM.Context;
using CRM.Domain.Interfaces;
using CRM.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CRMContext _context;
        public CustomerRepository(CRMContext context)
        {
            _context = context;
        }

        public void Add(Customer customer)
        {
            _context.Add(customer);
        }

        public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .Where(item => item.Id == id)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }
    }
}
