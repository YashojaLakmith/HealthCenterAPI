using Application.Authentication.Abstractions.CQRS;
using Application.Authentication.Commands;

using Authentication.Abstractions.Services;
using Authentication.ValueObjects;

using Domain.Common;
using Domain.ValueObjects;

namespace Application.Authentication.CommandHandlers;
internal class LoginCommandHandler : ICommandHandler<SessionToken, LoginCommand>
{
    private readonly IPasswordAuthenticationService _authenticationService;

    public LoginCommandHandler(IPasswordAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<Result<SessionToken>> HandleAsync(LoginCommand command, CancellationToken cancellationToken = default)
    {
        var emailResult = EmailAddress.CreateEmailAddress(command.EmailAddress);
        if (emailResult.IsFailure)
        {
            return Result<SessionToken>.Failure(emailResult.Error);
        }

        var pwResult = Password.CreatePassword(command.Password);
        if (pwResult.IsFailure)
        {
            return Result<SessionToken>.Failure(pwResult.Error);
        }

        return await _authenticationService.AuthenticateWithPasswordAsync(emailResult.Value, pwResult.Value, cancellationToken);
    }
}
