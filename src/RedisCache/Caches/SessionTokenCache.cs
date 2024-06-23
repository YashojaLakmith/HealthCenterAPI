using DistributedRedisCache.Abstractions;

using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Options;

namespace DistributedRedisCache.Caches;
internal sealed class SessionTokenCache : RedisCache, IDistributedSessionCache
{
    public SessionTokenCache(IOptions<RedisCacheOptions> optionsAccessor) : base(optionsAccessor)
    {
    }
}
