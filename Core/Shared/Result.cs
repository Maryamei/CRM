namespace CRM.Domain.Shared
{
    public class Result
    {
        protected Result(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;

        public Error Error { get; }

        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);

    }

    public class Result<T> : Result
    {
        private readonly T? _value;

        protected internal Result(bool isSuccess, T? value, Error error) : base(isSuccess, error) => _value = value;

        public T Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException("The value of a failure result can not be accessed.");


        public static Result<T> Success(T value) => new(true, value, Error.None);
        public new static Result<T> Failure(Error error) => new(false, default, error);
    }
}
