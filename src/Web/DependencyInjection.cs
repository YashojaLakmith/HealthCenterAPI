using Domain.Repositories;

using Infrastructure;

using Repositories;

namespace Web;

internal static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IWebHostEnvironment hostEnvironment)
    {
        services.AddControllers(options =>
        {
            options.SuppressAsyncSuffixInActionNames = false;
        });

        services.AddDataBase();
        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddDataBase(this IServiceCollection services)
    {
        // Add db connection string service
        services.AddDbContext<ApplicationDbContext>();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped(typeof(IRepository<>), typeof(RepositoryImpl<>));
    }
}
