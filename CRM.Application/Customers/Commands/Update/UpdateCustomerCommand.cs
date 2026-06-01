using CRM.Domain.Shared;
using MediatR;

namespace CRM.Application.Customers.Commands.Update
{
    public record UpdateCustomerCommand(Guid Id, string Name, string Address, string PhoneNumber) : IRequest<Result>;
}
