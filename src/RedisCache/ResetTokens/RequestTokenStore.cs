using System.Security.Claims;

using Authentication.Repositories;
using Authentication.ValueObjects;

using DistributedRedisCache.Abstractions;

using Domain.Common;

using Microsoft.Extensions.Caching.Distributed;

namespace DistributedRedisCache.ResetTokens;
internal sealed class RequestTokenStore : IResetTokenStore
{
    private readonly IDistributedResetTokenCache _requestTokenCache;
    private readonly DistributedCacheEntryOptions _cacheOptions;

    public RequestTokenStore(IDistributedResetTokenCache requestTokenCache, Options options)
    {
        _requestTokenCache = requestTokenCache;
        _cacheOptions = new()
        {
            SlidingExpiration = options.ResetTokenTimeout
        };
    }

    public Task<Result<IReadOnlyCollection<Claim>>> GetTokenClaimsAsync(ResetToken resetToken, CancellationToken tokenCancellationToken = default)
    {
        throw new NotImplementedException();
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
