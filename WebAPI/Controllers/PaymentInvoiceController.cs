using Microsoft.AspNetCore.Mvc;

using WebAPI.DataTransferObjects.Common;
using WebAPI.DataTransferObjects.PaymentInvoice;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/payment-invoice")]
public class PaymentInvoiceController : ControllerBase
{
    [HttpGet]
    [Route(@"{userId}/")]
    public Task<IActionResult> ListInvoicesByUserAsync(
        [FromRoute] string userId,
        [FromQuery] Pagination pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> ListInvoicesAsync(
        [FromQuery] InvoiceFilter filter,
        [FromQuery] Pagination pagination)
    {
        throw new NotImplementedException();
    }
}
