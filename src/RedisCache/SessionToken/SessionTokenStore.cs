using System.Security.Claims;

using Authentication.Repositories;

using Domain.Common;

namespace DistributedRedisCache.SessionToken;
internal sealed class SessionTokenStore : ISessionTokenStore
{
    public Task<Result> AddTokenAsync(Authentication.ValueObjects.SessionToken token, byte[] serializedClaims, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IReadOnlyCollection<Claim>>> GetAssociatedClaimsAsync(Authentication.ValueObjects.SessionToken sessionToken, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result> RefreshTokenAsync(Authentication.ValueObjects.SessionToken sessionToken, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result> RevokeTokenAsync(Authentication.ValueObjects.SessionToken sessionToken, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
