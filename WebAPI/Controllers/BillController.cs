using Microsoft.AspNetCore.Mvc;

using WebAPI.DataTransferObjects.Common;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/bill/")]
public class BillController : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> ListBillsAsync(
        [FromQuery] Pagination pagination,
        [FromQuery] string sortBy = @"default")
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{userId}/")]
    public Task<IActionResult> ListBillsByUserAsync(
        [FromRoute] string userId,
        [FromQuery] Pagination pagination,
        [FromQuery] string sortBy = @"default",
        [FromQuery] bool excludePaid = true)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"view/{billId}/")]
    public Task<IActionResult> ViewBillAsync(
        [FromRoute] string billId)
    {
        throw new NotImplementedException();
    }
}
