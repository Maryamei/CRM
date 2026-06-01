using CRM.Models;

namespace CRM.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        void Delete(Customer customer);
    }
}
