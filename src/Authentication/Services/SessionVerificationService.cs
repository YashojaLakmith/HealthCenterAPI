using System.Security.Claims;
using Authentication.Abstractions.Services;
using Authentication.Errors;
using Authentication.Repositories;
using Authentication.ValueObjects;
using Domain.Common;

namespace Authentication.Services;

internal sealed class SessionVerificationService(ISessionTokenStore tokenStore)
    : ISessionVerificationService
{
    public async Task<Result<IReadOnlyCollection<Claim>>> GetClaimsAsync(SessionToken sessionToken, CancellationToken cancellationToken = default)
    {
        var serializedClaims = await tokenStore.GetAssociatedClaimsAsync(sessionToken, cancellationToken);
        if (serializedClaims.IsFailure)
        {
            return Result<IReadOnlyCollection<Claim>>.Failure(TokenErrors.InvalidToken);
        }

        return await ClaimSerializer.DeserializeClaimsAsync(serializedClaims.Value, cancellationToken);
    }

    public async Task<Result> ExtendSessionAsync(SessionToken sessionToken, CancellationToken cancellationToken = default)
    {
        return await tokenStore.RefreshTokenAsync(sessionToken, cancellationToken);
    }
}