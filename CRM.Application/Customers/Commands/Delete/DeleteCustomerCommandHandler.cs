using CRM.Domain.Interfaces;
using CRM.Domain.Shared;
using MediatR;

namespace CRM.Application.Customers.Commands.Delete
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Result>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }
        public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);
            if (customer == null)
            {
                return Result.Failure(CustomerErrors.NotFound);
            }

            _customerRepository.Delete(customer);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result.Success();
        }
    }
}
