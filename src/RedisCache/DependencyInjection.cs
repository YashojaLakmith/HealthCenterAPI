using Authentication.Repositories;

using DistributedRedisCache.Abstractions;
using DistributedRedisCache.Caches;
using DistributedRedisCache.ResetTokens;
using DistributedRedisCache.SessionToken;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Options = DistributedRedisCache.Abstractions.Options;

namespace DistributedRedisCache;
public static class DependencyInjection
{
    public static IServiceCollection AddDistributedTokenStoring(
        this IServiceCollection services,
        Action<DistributedCacheEntryOptions> resetTokenConfigure,
        Action<DistributedCacheEntryOptions> sessionTokenConfigure,
        Action<RedisCacheOptions> resetCacheConfigure,
        Action<RedisCacheOptions> sessionCacheConfigure)
    {
        services.AddSingleton<IResetTokenStore>(sp =>
        {
            var options = new DistributedCacheEntryOptions();
            resetTokenConfigure(options);
            var cache = sp.GetRequiredService<IDistributedResetTokenCache>();
            return new RequestTokenStore(cache, options);
        });
        
        services.AddSingleton<ISessionTokenStore>(sp =>
        {
            var options = new DistributedCacheEntryOptions();
            sessionTokenConfigure(options);
            var cache = sp.GetRequiredService<IDistributedSessionCache>();
            return new SessionTokenStore(cache, options);
        });

        services.AddSingleton<IDistributedResetTokenCache>(sp =>
        {
            var optionsAccessor = sp.GetRequiredService<IOptions<RedisCacheOptions>>();
            resetCacheConfigure(optionsAccessor.Value);
            return new ResetTokenCache(optionsAccessor);
        });

        services.AddSingleton<IDistributedSessionCache>(sp =>
        {
            var optionsAccessor = sp.GetRequiredService<IOptions<RedisCacheOptions>>();
            sessionCacheConfigure(optionsAccessor.Value);
            return new SessionTokenCache(optionsAccessor);
        });

        return services;
    }
}
