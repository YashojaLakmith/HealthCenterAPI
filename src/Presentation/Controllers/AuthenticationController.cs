using Application.Authentication.Abstractions.Factories;
using Application.Authentication.Commands;
using Authentication.ValueObjects;
using Domain.Common;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Utilities;

namespace Presentation.Controllers;

[NestedRoute<AuthenticationController>(@"auth/")]
public class AuthenticationController(
    IAuthenticationCommandHandlerFactory commandHandlers,
    ILogger<AuthenticationController> logger)
    : BaseController(logger)
{
    [HttpPost]
    [Route(@"login/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> LoginAsync(
        [FromBody] LoginCommand loginInformation)
    {
        return await HandleActionAsync(async () =>
        {
            var result = await commandHandlers.LoginCommandHandler.HandleAsync(loginInformation);
            if (result.IsSuccess)
            {
                AttachSessionTokens(result.Value);
                return Ok();
            }

            return result.Error == RepositoryErrors.NotFoundError
                ? NotFound(result.Error)
                : BadRequest(result.Error);
        });
    }

    [HttpGet]
    [Route(@"logout/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> LogoutAsync()
    {
        var cookieName = nameof(SessionToken);
        var headerName = @"Authorization";

        if (HttpContext.Request.Cookies.TryGetValue(cookieName, out var cookieToken))
        {
            return await HandleActionAsync(async () =>
            {
                HttpContext.Response.Cookies.Delete(cookieName);
                var result = await commandHandlers.LogoutCommandHandler.HandleAsync(new LogoutCommand(cookieToken));
                return result.IsFailure
                    ? BadRequest(result.Error)
                    : Ok();
            });
        }

        if (HttpContext.Request.Headers.TryGetValue(headerName, out var headerToken))
        {
            return await HandleActionAsync(async () =>
            {
                HttpContext.Response.Headers.Remove(nameof(SessionToken));
                var result = await commandHandlers.LogoutCommandHandler.HandleAsync(new LogoutCommand(headerToken));
                return result.IsFailure
                    ? BadRequest(result.Error)
                    : Ok();
            });
        }
        
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"request-reset-token/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RequestPasswordResetTokenAsync(
        [FromRoute] ResetTokenRequestCommand tokenRequestCommand)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"change-password/")]
    [ProducesResponseType(StatusCodes.Status307TemporaryRedirect)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ChangePasswordAsync(
        [FromBody] ChangePasswordCommand changePasswordCommand)
    {
        return await HandleActionAsync(async () =>
        {
            var result = await commandHandlers.ChangePasswordCommandHandler.HandleAsync(changePasswordCommand);
            if (result.IsSuccess)
            {
                return RedirectToActionPreserveMethod(nameof(LogoutAsync));
            }

            return result.Error == RepositoryErrors.NotFoundError
                ? NotFound(result.Error)
                : BadRequest(result.Error);
        });
    }

    [HttpPatch]
    [Route(@"reset-password/")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ChangePasswordWithResetTokenAsync(
        [FromRoute] ResetPasswordCommand resetPasswordCommand)
    {
        return await HandleActionAsync(async () =>
        {
            var result = await commandHandlers.ResetPasswordCommandHandler.HandleAsync(resetPasswordCommand);
            return result.IsFailure
                ? BadRequest(result.Error)
                : NoContent();
        });
    }

    private void AttachSessionTokens(SessionToken sessionToken)
    {
        HttpContext.Response.Cookies.Append(nameof(SessionToken), sessionToken.Value);
        HttpContext.Response.Headers.Append(nameof(SessionToken), sessionToken.Value);
    }
}
