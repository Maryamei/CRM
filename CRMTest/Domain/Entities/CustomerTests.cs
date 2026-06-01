using CRM.Domain.Shared;
using CRM.Models;
using FluentAssertions;

namespace CRM.Test.Domain.Entities
{
    public class CustomerTests
    {
        [Fact]
        public void Create_WithValidData_ShouldCreateSuccefully()
        {
            string name = "مریم افتخاری";
            string address = "تهران";
            string phoneNum = "09129443530";

            var result = Customer.CreateCustomer(name, address, phoneNum);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.Name.Should().Be(name);
            result.Value.Address.Should().Be(address);
            result.Value.PhoneNumber.Should().Be(phoneNum);
            result.Value.IsActive.Should().BeTrue();
            result.Value.Id.Should().NotBeEmpty();
        }

        public static IEnumerable<object[]> GetInvalidCustomerData()
        {
            yield return new object[] { "", "Tehran", "09919443530", CustomerErrors.InvalidCustomerName };
            yield return new object[] { " ", "Tehran", "09919443530", CustomerErrors.InvalidCustomerName };
            yield return new object[] {"Maryam", "", "09919443530", CustomerErrors.InvalidCustomerAddress };
            yield return new object[] { "Maryam", "         ", "09919443530", CustomerErrors.InvalidCustomerAddress };
            yield return new object[] {"Maryam", "Tehran", "", CustomerErrors.InvlidPhoneNumber };
            yield return new object[] { "Maryam", "Tehran", " ", CustomerErrors.InvlidPhoneNumber };
            yield return new object[] {"Maryam", "Tehran", "0991944", CustomerErrors.InvlidPhoneNumber};
            yield return new object[] { "Maryam", "Tehran", "099194435630", CustomerErrors.InvlidPhoneNumber};
        }

        [Theory]
        [MemberData(nameof(GetInvalidCustomerData))]
        public void Create_WithInvalidInputs_ShouldThrowMessage(
            string name, string address, string phoneNumber, Error error)
        {
            var result = Customer.CreateCustomer(name, address, phoneNumber);
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(error);
        }
    }
}