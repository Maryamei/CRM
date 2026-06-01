using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Application.Common.Interfaces;
using CRM.Application.Customers.Commands.Create;
using CRM.Application.Customers.Commands.Update;
using CRM.Domain.Interfaces;
using CRM.Domain.Shared;
using CRM.Models;
using FluentAssertions;
using MockQueryable;
using Moq;

namespace CRM.Test.Application.Customers.Commands
{
    public class UpdateCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepo;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly UpdateCustomerCommandHandler _handler;
        public UpdateCustomerCommandHandlerTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockCustomerRepo = new Mock<ICustomerRepository>();
            _handler = new UpdateCustomerCommandHandler(_mockCustomerRepo.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task Handle_ShoulBeSuccess_WhenCustomerIsValid()
        {
            //Arrange
            var customer = Customer.CreateCustomer("Maryam Efyiwyui", "Teh", "12345678945").Value;
            _mockCustomerRepo.Setup(s => s.GetByIdAsync(customer.Id, It.IsAny<CancellationToken>())).ReturnsAsync(customer);
            var updateReq = new UpdateCustomerCommand(customer.Id, "Maryam Eftekhari", "Tehran", "09124587879");

            //Act
            var result = await _handler.Handle(updateReq, CancellationToken.None);

            //Assert
            result.IsSuccess.Should().BeTrue();
            customer.Name.Should().Be("Maryam Eftekhari");
            customer.Address.Should().Be("Tehran");
            customer.PhoneNumber.Should().Be("09124587879");
            _mockUnitOfWork.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ShoulBeFailure_WhenCustomerIsNotFound()
        {
            //Arrange
            var updateReq = new UpdateCustomerCommand(Guid.NewGuid(), "Maryam Eftekhari", "Tehran", "09124587879");

            //Act
            var result = await _handler.Handle(updateReq, CancellationToken.None);

            //Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Type.Should().Be(ErrorType.NotFound);
            _mockUnitOfWork.Verify(v => v.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
