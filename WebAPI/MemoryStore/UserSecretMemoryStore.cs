using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

using WebAPI.Abstractions.DataStore;

namespace WebAPI.MemoryStore;

public class UserSecretMemoryStore : MemoryCache, IUserSecretCache
{
    public UserSecretMemoryStore(IOptions<MemoryCacheOptions> optionsAccessor) : base(optionsAccessor)
    {
    }
}

public static class UserSecretStoreExtensions
{
    public static IServiceCollection AddInMemorySecretStore(this IServiceCollection services, Action<MemoryCacheOptions> configure)
    {
        services.AddSingleton<IUserSecretCache>(container =>
        {
            var options = container.GetRequiredService<IOptions<MemoryCacheOptions>>();
            configure(options.Value);
            return new UserSecretMemoryStore(options);
        });
        
        return services;
    }

    public static IServiceCollection AddInMemorySecretStore(this IServiceCollection services)
    {
        services.AddSingleton<IUserSecretCache>(container =>
        {
            var options = container.GetRequiredService<IOptions<MemoryCacheOptions>>();
            return new UserSecretMemoryStore(options);
        });

        return services;
    }
}
