using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route(@"/")]
public class AdminController : ControllerBase
{
    [HttpGet]
    public string Greet()
    {
        return @"Hello world";
    }
}
