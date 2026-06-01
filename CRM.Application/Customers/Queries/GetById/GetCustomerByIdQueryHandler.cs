using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Application.Common.Interfaces;
using CRM.Domain.Interfaces;
using CRM.Domain.Shared;
using CRM.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.Customers.Queries.GetById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Result<CustomerDto>>
    {
        private readonly IReadDbContext _readDbContext;
        public GetCustomerByIdQueryHandler(IReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<Result<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _readDbContext
                  .GetBaseQuery<Customer>()
                  .Where(c => c.Id == request.Id)
                  .Select(c => new CustomerDto(c.Id, c.Name, c.Address, c.PhoneNumber, c.City ?? string.Empty, c.IsActive))
                  .FirstOrDefaultAsync();
            if(customer == null)
            {
                return Result<CustomerDto>.Failure(CustomerErrors.NotFound);
            }

            return Result<CustomerDto>.Success(customer);
        }
    }
}
