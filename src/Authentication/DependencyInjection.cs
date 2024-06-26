using Authentication.Abstractions.Services;
using Authentication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication;
public static class DependencyInjection
{
    public static IServiceCollection AddAuthenticationDomain(this IServiceCollection services)
    {
        return services
            .AddScoped<IPasswordAuthenticationService, PasswordAuthenticationService>()
            .AddScoped<IResetTokenRequetService, ResetTokenRequestService>()
            .AddScoped<ITokenBasedPasswordResetService, TokenBasedPasswordResetService>();
    }
}
