using CRM.Application.Common.Extention;
using CRM.Domain.Shared;
using FluentValidation;

namespace CRM.Application.Customers.Commands.Create
{
    public class CreateCustomerCommandValidation : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithError(CustomerErrors.InvalidCustomerName)
                .MaximumLength(50).WithError(CustomerErrors.MaxLength);

            RuleFor(c => c.PhoneNumber).NotEmpty()
                .MaximumLength(11).WithError(CustomerErrors.InvlidPhoneNumber);

            RuleFor(c => c.Address)
                .NotEmpty().WithError(CustomerErrors.InvalidCustomerAddress);
        }
    }
}
