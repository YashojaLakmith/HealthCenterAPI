using System.Security.Claims;

using Authentication.Repositories;
using Authentication.ValueObjects;

using DistributedRedisCache.Abstractions;

using Domain.Common;
using Domain.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace DistributedRedisCache.ResetTokens;
internal sealed class RequestTokenStore : IResetTokenStore
{
    private readonly IDistributedResetTokenCache _requestTokenCache;
    private readonly DistributedCacheEntryOptions _cacheOptions;

    public RequestTokenStore(IDistributedResetTokenCache requestTokenCache, DistributedCacheEntryOptions options)
    {
        _requestTokenCache = requestTokenCache;
        _cacheOptions = options;
    }

    public async Task<Result<byte[]>> GetTokenClaimsAsync(ResetToken resetToken, CancellationToken cancellationToken = default)
    {
        var storedClaims = await _requestTokenCache.GetAsync(resetToken.Value, cancellationToken);
        return storedClaims ?? Result<byte[]>.Failure(RepositoryErrors.NotFoundError);
    }

    public async Task RemoveTokenAsync(ResetToken resetToken, CancellationToken cancellationToken = default)
    {
        await _requestTokenCache.RemoveAsync(resetToken.Value, cancellationToken);
    }

    public async Task SetTokenAsync(ResetToken resetToken, byte[] serializedClaims, CancellationToken cancellationToken = default)
    {
        await _requestTokenCache.SetAsync(resetToken.Value, serializedClaims, _cacheOptions, cancellationToken);
    }
}
