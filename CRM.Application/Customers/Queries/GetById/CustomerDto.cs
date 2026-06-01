namespace CRM.Application.Customers.Queries.GetById
{
    public record CustomerDto(Guid Id, string Name, string Address, string PhoneNumber, string City, bool IsActive);
}