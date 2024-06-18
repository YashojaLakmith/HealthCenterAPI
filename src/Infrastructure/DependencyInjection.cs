using Domain.Repositories;

using Infrastructure.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services.AddDbContext<ApplicationDbContext>()
                        .AddScoped<IApplicationDbContext, ApplicationDbContext>()
                        .AddScoped<IUnitOfWork, ApplicationDbContext>();
    }
}
