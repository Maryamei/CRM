namespace CRM.Domain.Shared
{
    public record Error(string Code, string Description, ErrorType Type)
    {
        public static Error None = new(string.Empty, string.Empty, ErrorType.None);
    }
}
