using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Application.Customers.Commands.Create;
using CRM.Domain.Interfaces;
using CRM.Models;
using FluentAssertions;
using Moq;

namespace CRM.Test.Application.Customers.Commands
{
    public class CreateCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepo;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CreateCustomerCommandHandler _handler;

        public CreateCustomerCommandHandlerTests()
        {
            _mockCustomerRepo = new Mock<ICustomerRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new CreateCustomerCommandHandler(_mockCustomerRepo.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccessResult_WhenCustomerIsValid()
        {
            var command = new CreateCustomerCommand("مریم افتخاری", "تهران", "09120000000");
            var result = await _handler.Handle(command, default);
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBe(Guid.Empty);
            _mockCustomerRepo.Verify(repo => repo.Add(It.IsAny<Customer>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()));
        }
    }
}
