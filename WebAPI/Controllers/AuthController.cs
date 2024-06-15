using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;

using WebAPI.Abstractions.Services;
using WebAPI.Authentication;
using WebAPI.DataTransferObjects.Login;
using WebAPI.Exceptions;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/auth/")]
public class AuthController : ControllerBase
{
    private readonly IAuthServices _authServices;
    private readonly ILogger _logger;

    public AuthController(IAuthServices authServices, ILogger logger)
    {
        _authServices = authServices;
        _logger = logger;
    }

    [HttpPost]
    [Route(@"login/")]
    [ProducesResponseType<string>(200)]
    [ProducesResponseType(200)]
    [ProducesResponseType<string>(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> LoginAsync(
        [FromBody] LoginInformation patientLoginData,
        [FromQuery] bool isBearerAuthentication = false)
    {
        try
        {
            var token = await _authServices.HandlePatientLoginAsync(patientLoginData);
            return TryReturnSession(token, isBearerAuthentication);
        }
        catch(AuthenticationFailureException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, null);
            throw;
        }
    }

    [HttpGet]
    [Route(@"logout")]
    [ProducesResponseType(401)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> LogoutAsync()
    {
        var token = GetToken();

        if(token is null)
        {
            return Unauthorized();
        }

        await _authServices.HandleLogoutAsync(token);
        return NoContent();
    }

    [NonAction]
    private IActionResult TryReturnSession(string toksn, bool isBearerAuth)
    {
        if (!isBearerAuth)
        {
            Response.Cookies.Append(UserAuthenticationHandler.SessionCookieName, toksn);
            return Ok();
        }

        return Ok(toksn);
    }

    private string? GetToken()
    {
        var claims = HttpContext.User.Claims;
        var token = claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.AuthenticationInstant));
        return token?.Value;
    }
}
