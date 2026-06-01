using CRM.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected IActionResult GetResult(Error error)
        {
            return error.Type switch
            {
                ErrorType.NotFound => NotFound(error),
                ErrorType.BadRequest => BadRequest(error),
                ErrorType.Ok => Ok(error),
                _ => Ok(),
            };
        }
    }
}
