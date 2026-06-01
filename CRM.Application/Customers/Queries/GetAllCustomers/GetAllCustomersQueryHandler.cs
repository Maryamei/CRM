using CRM.Application.Common.Extention;
using CRM.Application.Common.Interfaces;
using CRM.Application.Common.Models;
using CRM.Application.Customers.Queries.GetById;
using CRM.Domain.Shared;
using CRM.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, Result<PagedResult<CustomerDto>>>
    {
        private readonly IReadDbContext _readDbContext;
        public GetAllCustomersQueryHandler(IReadDbContext readDbContext)
        {
             _readDbContext = readDbContext;
        }

        public async Task<Result<PagedResult<CustomerDto>>> Handle(
            GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var query = _readDbContext
                .GetBaseQuery<Customer>();
            int totalCount = await query.CountAsync(cancellationToken);
            var customers = await query
                .OrderBy(c => c.Id)
                .ApplyPaging(request.PageNumber, request.PageSize)
                .Select(c => new CustomerDto(c.Id, c.Name, c.Address, c.PhoneNumber, c.City ?? String.Empty, c.IsActive))
                .ToListAsync(cancellationToken);
            var pagedList = new PagedResult<CustomerDto>(customers, totalCount, request.PageNumber, request.PageSize);

            return Result<PagedResult<CustomerDto>>.Success(pagedList);
        }
    }
}
