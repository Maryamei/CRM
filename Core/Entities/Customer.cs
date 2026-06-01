using CRM.Domain.Shared;

namespace CRM.Models
{
    public class Customer
    {
        public Guid Id { get; private set; } 
        public string Name { get; private set; } = null!;
        public string Address { get; private set; } = null!;
        public string? City { get; private set; }
        public string? Region { get; private set; }
        public string? PostalCode { get; private set; }
        public string PhoneNumber { get; private set; } = null!;
        public bool IsActive { get; private set; }

        private Customer() { }

        public static Result<Customer> CreateCustomer(string name, string address, string phoneNumber)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return Result<Customer>.Failure(CustomerErrors.InvalidCustomerName);
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                return Result<Customer>.Failure(CustomerErrors.InvalidCustomerAddress);
            }

            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length != 11)
            {
                return Result<Customer>.Failure(CustomerErrors.InvlidPhoneNumber);
            }
            return Result<Customer>.Success(new Customer
            {
                Id = Guid.NewGuid(),
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                IsActive = true
            });
        }

        public Result UpdateCustomer(string name, string address, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure(CustomerErrors.InvalidCustomerName);
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                return Result.Failure(CustomerErrors.InvalidCustomerAddress);
            }

            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length != 11)
            {
                return Result.Failure(CustomerErrors.InvlidPhoneNumber);
            }
            
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;

            return Result.Success();
        }
    }
}
