using Microsoft.AspNetCore.Mvc;

using Services.DataTransferObjects.LoginAndPasswords;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/forgot-password/")]
public class ForgottenPasswordController : ControllerBase
{
    [HttpGet]
    [Route(@"{userId}/")]
    public Task<IActionResult> RequestPasswordResetTokenAsync(
        [FromRoute] string userId,
        [FromQuery] string userType)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    public Task<IActionResult> ResetPasswordUsingTokenAsync(
        [FromBody] TokenBasedPasswordResetData tokenBasedPwResetParams)
    {
        throw new NotImplementedException();
    }
}
