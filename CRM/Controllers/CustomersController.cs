using CRM.Application.Customers.Commands.Create;
using CRM.Application.Customers.Commands.Delete;
using CRM.Application.Customers.Commands.Update;
using CRM.Application.Customers.Queries.GetAllCustomers;
using CRM.Application.Customers.Queries.GetById;
using CRM.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ApiController
    {
        private readonly IMediator _mediatR;

        public CustomersController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand createCustomer)
        {
            var result = await _mediatR.Send(createCustomer);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.Error });
            }

            return Ok(new { CustomerId = result.Value, Message = "مشتری با موفقیت ثبت شد." });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers([FromQuery] GetAllCustomersQuery command, CancellationToken cancellationToken)
        {
            var result = await _mediatR.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return GetResult(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var commandQry = new GetCustomerByIdQuery(id);
            var result = await _mediatR.Send(commandQry);

            if (!result.IsSuccess)
            {
                return GetResult(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerCommand updateCustomer)
        {
            var command = updateCustomer with { Id = id };
            var result = await _mediatR.Send(command);

            if (result.IsFailure)
            {
                return GetResult(result.Error);
            }

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var command = new DeleteCustomerCommand(id);
            var result = await _mediatR.Send(command);

            if(result.IsFailure)
            {
                return GetResult(result.Error);
            }

            return Ok();
        }
    }
}
