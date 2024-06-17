using AzureKeyVaultSecrets;

using Infrastructure;

using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Options;

using Web.Abstractions;
using Web.Redis;

namespace Web.Configure;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(IServiceCollection services, IWebHostEnvironment environment)
    {
        ConfigureControllers(services);

        services.AddDbContext<ApplicationDbContext>();

        ConfigureDbConnectionString(services, environment);

        ConfigureSessionManager(services);

        ConfigureRedisCache(services, environment);

        return services;
    }

    private static void ConfigureControllers(IServiceCollection services)
    {
        var assembly = typeof(Presentation.AssemblyOptions).Assembly;
        var part = new AssemblyPart(assembly);

        services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = true)
            .ConfigureApplicationPartManager(partManager => partManager.ApplicationParts.Add(part));
    }

    private static void ConfigureDbConnectionString(IServiceCollection services, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {

        }
        else
        {
            services.AddSingleton<IDbConnectionString, KeyVaultConnectionString>();
        }
    }

    private static void ConfigureSessionManager(IServiceCollection services)
    {
       
    }

    private static void ConfigureRedisCache(IServiceCollection services, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {

        }
        else
        {
            services.AddSingleton<IDistributedSessionCache>(sp =>
            {
                var redisOptions = sp.GetRequiredService<IOptions<RedisCacheOptions>>();

                return new RedisSessionCache(redisOptions);
            });
        }
    }
}
