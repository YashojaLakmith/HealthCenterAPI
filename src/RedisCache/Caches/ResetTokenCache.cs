using DistributedRedisCache.Abstractions;

using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Options;

namespace DistributedRedisCache.Caches;
internal sealed class ResetTokenCache : RedisCache, IDistributedResetTokenCache
{
    public ResetTokenCache(IOptions<RedisCacheOptions> optionsAccessor) : base(optionsAccessor)
    {
    }
}
