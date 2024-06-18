using System.Security.Claims;

using Application.Authentication.Abstractions.CQRS;
using Application.Authentication.Abstractions.TokenManagement;
using Application.Authentication.Commands;

using Authentication.Entities;
using Authentication.Repositories;
using Authentication.ValueObjects;

using Domain.Common;
using Domain.ValueObjects;

namespace Application.Authentication.CommandHandlers;
internal class LoginCommandHandler : ICommandHandler<SessionToken, LoginCommand>
{
    private readonly IAuthServiceRepository _authRepository;
    private readonly ISessionManagement _sessionManager;

    public LoginCommandHandler(IAuthServiceRepository authRepository, ISessionManagement sessionManager)
    {
        _authRepository = authRepository;
        _sessionManager = sessionManager;
    }

    public async Task<Result<SessionToken>> HandleAsync(LoginCommand command, CancellationToken cancellationToken = default)
    {
        var emailResult = EmailAddress.CreateEmailAddress(command.EmailAddress);
        var pwResult = Password.CreatePassword(command.Password);
        var credentialResult = await _authRepository.GetCredentialObjectByEmailAsync(emailResult.Value, cancellationToken);

        var authenticateResult = credentialResult.Value.AuthenticateUsingPassword(pwResult.Value);
        if (!authenticateResult.IsSuccess)
        {
            return Result<SessionToken>.Failure(authenticateResult.Exception);
        }

        var claims = GetUserClaims(credentialResult.Value);
        return await _sessionManager.CreateSessionAsync(claims, cancellationToken);
    }

    private static List<Claim> GetUserClaims(Credentials credentials)
    {
        var claims = new List<Claim>();
        var user = credentials.User;

        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.Value.ToString()));
        claims.Add(new Claim(ClaimTypes.Name, user.UserName.Value));
        claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));

        return claims;
    }
}
