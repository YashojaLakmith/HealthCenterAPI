using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/bill/")]
public class BillController : ControllerBase
{
    [HttpGet]
    [Route(@"{userId}/")]
    public Task<IActionResult> ListBillsAsync([FromRoute] string userId, [FromQuery] bool excludePaid, [FromQuery] object pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{userId}/{billId}/")]
    public Task<IActionResult> ViewBillAsync([FromRoute] string userId, [FromRoute] string billId)
    {
        throw new NotImplementedException();
    }
}
