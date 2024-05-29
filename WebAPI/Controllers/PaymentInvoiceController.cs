using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/payment-invoice")]
public class PaymentInvoiceController : ControllerBase
{
    [HttpGet]
    [Route(@"{userId}/")]
    public Task<IActionResult> ListUserInvoices([FromRoute] string userId, [FromQuery] object pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> ListAllInvoices([FromBody] object filterParameters, [FromQuery] object pagination)
    {
        throw new NotImplementedException();
    }
}
