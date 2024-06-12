using WebAPI.Abstractions.Secrets;

namespace WebAPI.Secrets;

public class DevKeyVault : ICloudSecretStore
{
    public Task<string> GetSecretAsync(string key)
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
