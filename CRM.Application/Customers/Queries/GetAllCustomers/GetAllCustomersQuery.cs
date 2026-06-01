using CRM.Application.Common.Models;
using CRM.Application.Customers.Queries.GetById;
using CRM.Domain.Shared;
using MediatR;

namespace CRM.Application.Customers.Queries.GetAllCustomers
{
    public record GetAllCustomersQuery(int PageNumber = 1, int PageSize = 100) : IRequest<Result<PagedResult<CustomerDto>>>;
}