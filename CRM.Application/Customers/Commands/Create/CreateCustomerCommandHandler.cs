using CRM.Domain.Interfaces;
using CRM.Domain.Shared;
using CRM.Models;
using MediatR;

namespace CRM.Application.Customers.Commands.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<Guid>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerResult = Customer.CreateCustomer(request.Name, request.Address, request.PhoneNumber);
            if (!customerResult.IsSuccess || customerResult.Value == null)
            {
                return Result<Guid>.Failure(customerResult.Error);

            }

            _customerRepository.Add(customerResult.Value);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<Guid>.Success(customerResult.Value.Id);

        }
    }
}
