using WebAPI.Abstractions.DataStore;

namespace WebAPI.Secrets;

public class DevKeyVault : ICloudSecretStore
{
    public Task<string> GetDbConnectionStringAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetJwtSigningKeyAsync()
    {
        throw new NotImplementedException();
    }
}

public static class DevKeyVaultExtensions
{
    public static IServiceCollection AddDeveloperKeyStore(this IServiceCollection services)
    {
        return services.AddSingleton<ICloudSecretStore, DevKeyVault>();
    }
}
