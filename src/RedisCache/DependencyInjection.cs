using Authentication.Repositories;

using DistributedRedisCache.Abstractions;
using DistributedRedisCache.Caches;
using DistributedRedisCache.ResetTokens;
using DistributedRedisCache.SessionToken;

using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DistributedRedisCache;
public static class DependencyInjection
{
    public static IServiceCollection AddDistributedTokenStoring(this IServiceCollection services)
    {
        services.AddSingleton<IResetTokenStore, RequestTokenStore>();
        services.AddSingleton<ISessionTokenStore, SessionTokenStore>();
        services.AddSingleton<DistributedRedisCache.Abstractions.Options>();

        services.AddSingleton<IDistributedResetTokenCache>(sp =>
        {
            var optionsAccessor = sp.GetRequiredService<IOptions<RedisCacheOptions>>();

            return new ResetTokenCache(optionsAccessor);
        });

        services.AddSingleton<IDistributedSessionCache>(sp =>
        {
            var optionsAccessor = sp.GetRequiredService<IOptions<RedisCacheOptions>>();

            return new SessionTokenCache(optionsAccessor);
        });

        return services;
    }
}
