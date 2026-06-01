using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Application.Customers.Commands.Delete;
using CRM.Domain.Interfaces;
using CRM.Models;
using FluentAssertions;
using Moq;

namespace CRM.Test.Application.Customers.Commands
{
    public class DeleteCustomerCommandHandlerTests
    { 
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly DeleteCustomerCommandHandler _deleteCustomerCommandHandler;

        public DeleteCustomerCommandHandlerTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _deleteCustomerCommandHandler = new DeleteCustomerCommandHandler(
                _unitOfWork.Object, _customerRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldBeSuccess_WhenCustomerIsExist()
        {
            //Arrange
            var customer = Customer.CreateCustomer("Maryam Eftekhari", "Tehran", "09125446565").Value;
            _customerRepository.Setup(s => s.GetByIdAsync(
                customer.Id, It.IsAny<CancellationToken>())).ReturnsAsync(customer);
            var customerDeleteCommand = new DeleteCustomerCommand(customer.Id);

            //Act
            var result = await _deleteCustomerCommandHandler.Handle(
                customerDeleteCommand, CancellationToken.None);

            //Assert
            result.IsSuccess.Should().BeTrue();
            _unitOfWork.Verify(v => v.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldBeNotFound_WhenCustomerIsNotExist()
        {
            //Arrange
            var customerDeleteCommand = new DeleteCustomerCommand(Guid.NewGuid());

            //Act
            var result = await _deleteCustomerCommandHandler.Handle(
                customerDeleteCommand, CancellationToken.None);

            //Assert
            result.IsFailure.Should().BeTrue();
            _unitOfWork.Verify(v => v.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
