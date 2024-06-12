using Microsoft.AspNetCore.Mvc;

using WebAPI.DataTransferObjects.Payment;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/payment/")]
public class PaymentController : ControllerBase
{
    [HttpPost]
    [Route(@"cash/")]
    public Task<IActionResult> MakeCashPaymentAsync(
        [FromBody] CashPayment cashPaymentInfo)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route(@"card/")]
    public Task<IActionResult> MakeCardPaymentAsync(
        [FromBody] CardPayment cardPaymentInfo)
    {
        throw new NotImplementedException();
    }
}
