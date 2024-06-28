using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Utilities;

namespace Presentation.Controllers;

[ApiController]
[NestedRoute<BaseController>(@"/api/v1/")]
public abstract class BaseController(ILogger logger) : ControllerBase
{
    protected async Task<IActionResult> HandleActionAsync(Func<Task<IActionResult>> handler)
    {
        try
        {
            return await handler();
        }
        catch (Exception ex)
        {
            logger.LogError(@"Unhandled exception caught in the controllers. Error: {@Exception}", ex);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}