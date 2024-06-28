using Microsoft.AspNetCore.Mvc;
using Presentation.Utilities;

namespace Presentation.Controllers;

[ApiController]
[NestedRoute<HelloWorldController>(@"hello-world/")]
public sealed class HelloWorldController : ControllerBase
{
    [HttpGet]
    public IActionResult Greet()
    {
        return Ok(@"Hello world!.");
    }
}