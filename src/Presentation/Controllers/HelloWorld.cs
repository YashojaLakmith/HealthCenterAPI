using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route(@"api/v1/hello-world/")]
public sealed class HelloWorld : ControllerBase
{
    [HttpGet]
    public IActionResult Greet()
    {
        return Ok(@"Hello world!.");
    }
}