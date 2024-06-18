using Infrastructure.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace AzureKeyVaultSecrets;
public static class DependencyInjection
{
    public static IServiceCollection AddAzureKeyVault(this IServiceCollection services)
    {
        return services.AddSingleton<IDbConnectionString, KeyVaultConnectionString>();
    }
}
