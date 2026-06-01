namespace CRM.Domain.Shared
{
    public static class CustomerErrors
    {
        public static readonly Error InvalidCustomerName = new(
            "Customer.NameIsRequired",
            "نام مشتری اجباری است.",
            ErrorType.BadRequest);

        public static readonly Error InvalidCustomerAddress = new(
            "Customer.AddressIsRequired",
            "آدرس مشتری اجباری است.",
            ErrorType.BadRequest);

        public static readonly Error InvlidPhoneNumber = new(
            "Customer.PhoneNumberIsInvalid",
            "شماره مشتری نامعتبر است.", 
            ErrorType.BadRequest);

        public static readonly Error NotFound = new(
            "Customer.NotFound",
            "مشتری یافت نشد.", 
            ErrorType.NotFound);

        public static readonly Error MaxLength = new(
            "Customer.MaxLength",
            "طول نام نباید بیشتر از 50 کاراکتر باشد.",
            ErrorType.BadRequest);
    }
}
