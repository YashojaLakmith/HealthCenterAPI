using Microsoft.Extensions.DependencyInjection;

namespace Application.Authentication;
public static class DependencyInjection
{
    public static IServiceCollection AddAdminAuthentication(this IServiceCollection services)
    {
        return services;
    }
}
