using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Application.Common.Interfaces;
using CRM.Application.Customers.Queries.GetById;
using CRM.Models;
using FluentAssertions;
using Moq;
using MockQueryable.Moq;
using MockQueryable;
using CRM.Domain.Shared;


namespace CRM.Test.Application.Customers.Queries
{
    public class GetCustomerByIdQueryHandlerTests
    {
        private readonly Mock<IReadDbContext> _readDbContextMock;
        private readonly GetCustomerByIdQueryHandler _handler;

        public GetCustomerByIdQueryHandlerTests()
        {
            _readDbContextMock = new Mock<IReadDbContext>();
            _handler = new GetCustomerByIdQueryHandler(_readDbContextMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnCustomerDto_WhenCustomerExists()
        {
            //Arrange
            var customer = Customer.CreateCustomer("Maryam Eftekhari", "Tehran", "09121111111").Value!;
            var customers = new List<Customer> { customer }.BuildMock();
            _readDbContextMock.Setup(s => s.GetBaseQuery<Customer>()).Returns(customers);
            GetCustomerByIdQuery request = new(customer.Id);

            //Act
            var result = await _handler.Handle(request, CancellationToken.None);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.Name.Should().Be(customer.Name);
            result.Value.Address.Should().Be(customer.Address);
            result.Value.PhoneNumber.Should().Be(customer.PhoneNumber);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenCustomerDoesNotExist()
        {
            //Arrange
            var customers = new List<Customer>().BuildMock();
            _readDbContextMock.Setup(s => s.GetBaseQuery<Customer>()).Returns(customers);
            var query = new GetCustomerByIdQuery(Guid.NewGuid());

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(CustomerErrors.NotFound);
        }

    }
}
