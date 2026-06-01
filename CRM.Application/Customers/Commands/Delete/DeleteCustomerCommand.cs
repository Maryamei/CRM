using CRM.Domain.Shared;
using MediatR;

namespace CRM.Application.Customers.Commands.Delete
{
    public record DeleteCustomerCommand(Guid Id) : IRequest<Result>;
}
