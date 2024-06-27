using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Authentication.Abstractions.Factories;
using Application.Authentication.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route(@"auth/")]
public class AuthenticationController(
    IAuthenticationCommandHandlerFactory commandHandlers)
    : BaseController
{
    private readonly IAuthenticationCommandHandlerFactory _commandHandlers = commandHandlers;

    [HttpPost]
    [Route(@"login/")]
    public async Task<IActionResult> LoginAsync(
        [FromBody] LoginCommand loginInformation)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"logout/")]
    public async Task<IActionResult> LogoutAsync()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"request-reset-token/")]
    public async Task<IActionResult> RequestPasswordResetTokenAsync(
        [FromRoute] ResetTokenRequestCommand tokenRequestCommand)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"change-password/")]
    public async Task<IActionResult> ChangePasswordAsync(
        [FromBody] ChangePasswordCommand changePasswordCommand)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"reset-password/")]
    public async Task<IActionResult> ChangePasswordWithResetTokenAsync(
        [FromRoute] ResetPasswordCommand resetPasswordCommand)
    {
        throw new NotImplementedException();
    }
}
