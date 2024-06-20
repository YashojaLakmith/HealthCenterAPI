using Microsoft.Extensions.DependencyInjection;

namespace Authentication;
public static class DependencyInjection
{
    public static IServiceCollection AddAuthenticationDomain(this IServiceCollection services)
    {
        return services;
    }
}
