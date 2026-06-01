using CRM.Domain.Shared;
using FluentValidation;

namespace CRM.Application.Common.Extention
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule, Error error)
        {
            return error == null
                ? throw new ArgumentNullException(nameof(error))
                : rule.WithMessage(error.Description).WithErrorCode(error.Code);
        }
    }
}
