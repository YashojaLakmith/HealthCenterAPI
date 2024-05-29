using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/payment/")]
public class PaymentController : ControllerBase
{
    [HttpPost]
    [Route(@"cash/")]
    public Task<IActionResult> MakeCashPaymentAsync([FromBody] object cashPaymentInfo)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route(@"card/")]
    public Task<IActionResult> MakeCardPaymentAsync([FromBody] object cardPaymentInfo)
    {
        throw new NotImplementedException();
    }
}
