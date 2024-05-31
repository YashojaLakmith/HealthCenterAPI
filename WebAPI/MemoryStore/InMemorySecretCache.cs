using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

using WebAPI.Abstractions.DataStore;

namespace WebAPI.MemoryStore;

public class InMemorySecretCache : MemoryCache, ILocalSecretCache
{
    public InMemorySecretCache(IOptions<MemoryCacheOptions> optionsAccessor) : base(optionsAccessor)
    {
    }
}

public static class UserSecretStoreExtensions
{
    public static IServiceCollection AddInMemorySecretStore(this IServiceCollection services, Action<MemoryCacheOptions> configure)
    {
        services.AddSingleton<ILocalSecretCache>(container =>
        {
            var options = container.GetRequiredService<IOptions<MemoryCacheOptions>>();
            configure(options.Value);
            return new InMemorySecretCache(options);
        });
        
        return services;
    }

    public static IServiceCollection AddInMemorySecretCache(this IServiceCollection services)
    {
        services.AddSingleton<ILocalSecretCache>(container =>
        {
            var options = container.GetRequiredService<IOptions<MemoryCacheOptions>>();
            return new InMemorySecretCache(options);
        });

        return services;
    }
}
