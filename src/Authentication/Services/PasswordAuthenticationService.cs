using Authentication.Abstractions.Services;
using Authentication.Errors;
using Authentication.Repositories;
using Authentication.ValueObjects;
using Domain.Common;
using Domain.ValueObjects;

namespace Authentication.Services;

public class PasswordAuthenticationService : IPasswordAuthenticationService
{
    private readonly ICredentialRepository _credentialRepository;
    private readonly ISessionTokenStore _sessionTokenStore;

    public PasswordAuthenticationService(ICredentialRepository credentialRepository, ISessionTokenStore sessionTokenStore)
    {
        _credentialRepository = credentialRepository;
        _sessionTokenStore = sessionTokenStore;
    }

    public async Task<Result<SessionToken>> AuthenticateWithPasswordAsync(
        EmailAddress emailAddress,
        Password password,
        CancellationToken cancellationToken = default)
    {
        var credObjectResult = await _credentialRepository.GetCredentialObjectByEmailAsync(emailAddress, cancellationToken);
        if (credObjectResult.IsFailure)
        {
            return Result<SessionToken>.Failure(credObjectResult.Error);
        }

        if (!credObjectResult.Value.CanAuthenticateWithPassword(password))
        {
            return Result<SessionToken>.Failure(AuthenticationErrors.PasswordAuthenticationFailedError);
        }

        var claims = ClaimExtractor.ExtractClaims(credObjectResult.Value);
        var serializedClaims = await ClaimSerializer.SerializeClaimsAsync(claims, cancellationToken);
        var token = SessionToken.CreateToken();
        var newSessionResult = await _sessionTokenStore.AddTokenAsync(token, serializedClaims, cancellationToken);

        return newSessionResult.IsFailure ? Result<SessionToken>.Failure(newSessionResult.Error) : token;
    }
}