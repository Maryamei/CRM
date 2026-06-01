using CRM.Application.Customers.Queries.GetById;
using CRM.Domain.Interfaces;
using CRM.Domain.Shared;
using MediatR;

namespace CRM.Application.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
             _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);
            if (customer is null)
            {
                return Result.Failure(CustomerErrors.NotFound);
            }

            var result = customer.UpdateCustomer(request.Name, request.Address, request.PhoneNumber);

            if (result.IsFailure)
            {
                return result;
            }
                            
            await _unitOfWork.SaveChangesAsync(cancellationToken);            
            return Result.Success();
        }
    }
}
