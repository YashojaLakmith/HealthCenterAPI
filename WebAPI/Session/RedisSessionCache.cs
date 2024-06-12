using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Options;
using WebAPI.Abstractions.Caching;

namespace WebAPI.Session;

public class RedisSessionCache : RedisCache, ISessionCache
{
    public RedisSessionCache(IOptions<RedisCacheOptions> optionsAccessor) : base(optionsAccessor)
    {
    }
}

public static class RedisSessionCacheExtensions
{
    public static void AddRedisSessionCache(this IServiceCollection services, Action<RedisCacheOptions> configure)
    {
        services.AddSingleton<ISessionCache>(container =>
        {
            var options = container.GetRequiredService<IOptions<RedisCacheOptions>>();
            configure(options.Value);

            return new RedisSessionCache(options);
        });
    }
}
