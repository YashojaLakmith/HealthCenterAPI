using Authentication.Repositories;
using DistributedRedisCache.Abstractions;
using Domain.Common;
using Domain.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace DistributedRedisCache.SessionToken;
internal sealed class SessionTokenStore : ISessionTokenStore
{
    private readonly IDistributedSessionCache _sessionCache;
    private readonly DistributedCacheEntryOptions _options;

    public SessionTokenStore(IDistributedSessionCache sessionCache, DistributedCacheEntryOptions cachingOptions)
    {
        _sessionCache = sessionCache;
        _options = cachingOptions;
    }

    public async Task<Result> AddTokenAsync(Authentication.ValueObjects.SessionToken token, byte[] serializedClaims, CancellationToken cancellationToken = default)
    {
        await _sessionCache.SetAsync(token.Value, serializedClaims, _options, cancellationToken);
        return Result.Success();
    }

    public async Task<Result<byte[]>> GetAssociatedClaimsAsync(Authentication.ValueObjects.SessionToken sessionToken, CancellationToken cancellationToken = default)
    {
        var foundClaims = await _sessionCache.GetAsync(sessionToken.Value, cancellationToken);
        return foundClaims ?? Result<byte[]>.Failure(RepositoryErrors.NotFoundError);
    }

    public async Task<Result> RefreshTokenAsync(Authentication.ValueObjects.SessionToken sessionToken, CancellationToken cancellationToken = default)
    {
        await _sessionCache.RefreshAsync(sessionToken.Value, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> RevokeTokenAsync(Authentication.ValueObjects.SessionToken sessionToken, CancellationToken cancellationToken = default)
    {
        await _sessionCache.RemoveAsync(sessionToken.Value, cancellationToken);
        return Result.Success();
    }
}
