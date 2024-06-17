using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Options;

using Web.Abstractions;

namespace Web.Redis;

public class RedisSessionCache : RedisCache, IDistributedSessionCache
{
    public RedisSessionCache(IOptions<RedisCacheOptions> optionsAccessor) : base(optionsAccessor)
    {
    }
}
