using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/forgot-password/")]
public class ForgottenPasswordController : ControllerBase
{
    [HttpGet]
    [Route(@"{userId}/")]
    public Task<IActionResult> RequestPasswordResetTokenAsync([FromRoute] string userId, [FromQuery] object userType)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    public Task<IActionResult> ResetPasswordUsingTokenAsync([FromBody] object tokenBasedPwResetParams)
    {
        throw new NotImplementedException();
    }
}
