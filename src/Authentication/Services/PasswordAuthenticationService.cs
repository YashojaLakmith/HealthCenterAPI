using System.Security.Claims;

using Authentication.Abstractions.Services;
using Authentication.Entities;
using Authentication.Errors;
using Authentication.Repositories;
using Authentication.ValueObjects;

using Domain.Common;
using Domain.ValueObjects;

namespace Authentication.Services;
public sealed class PasswordAuthenticationService : IPasswordAuthenticationService
{
    private readonly ISessionTokenStore _sessionStore;
    private readonly IAuthServiceRepository _credRepository;

    public PasswordAuthenticationService(ISessionTokenStore sessionStore, IAuthServiceRepository credRepository)
    {
        _sessionStore = sessionStore;
        _credRepository = credRepository;
    }

    public async Task<Result<SessionToken>> AuthenticateWithPasswordAsync(EmailAddress emailAddress, Password password, CancellationToken cancellationToken = default)
    {
        var credentialResult = await _credRepository.GetCredentialObjectByEmailAsync(emailAddress, cancellationToken);
        if (credentialResult.IsFailure)
        {
            return Result<SessionToken>.Failure(credentialResult.Error);
        }

        if (!credentialResult.Value.CanAuthenticateWithPassword(password))
        {
            return Result<SessionToken>.Failure(AuthenticationErrors.PasswordAuthenticationFailedError);
        }

        var newToken = SessionToken.CreateToken();
        var claims = ClaimExtractor.ExtractClaims(credentialResult.Value);
        var serializedClaims = await ClaimSerializer.SerializeClaimsAsync(claims, cancellationToken);

        var insertResult = await _sessionStore.AddTokenAsync(newToken, serializedClaims, cancellationToken);
        if (insertResult.IsFailure)
        {
            return Result<SessionToken>.Failure(insertResult.Error);
        }

        return newToken;
    }

}
