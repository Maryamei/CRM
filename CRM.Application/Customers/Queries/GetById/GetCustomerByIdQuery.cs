using CRM.Domain.Shared;
using MediatR;

namespace CRM.Application.Customers.Queries.GetById
{
    public record GetCustomerByIdQuery(Guid Id) : IRequest<Result<CustomerDto>>;
}