using CRM.Domain.Shared;
using MediatR;

namespace CRM.Application.Customers.Commands.Create
{
    public record CreateCustomerCommand(string Name, string Address, string PhoneNumber) : IRequest<Result<Guid>>;
}
