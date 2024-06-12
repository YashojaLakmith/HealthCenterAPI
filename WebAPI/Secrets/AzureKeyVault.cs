using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

using WebAPI.Abstractions.Secrets;

namespace WebAPI.Secrets;

public class AzureKeyVault : ICloudSecretStore
{
    private readonly IConfiguration _configuration;
    private readonly string _keyVaultUri;

    public AzureKeyVault(IConfiguration configuration)
    {
        _configuration = configuration;
        _keyVaultUri = $@"https://{GetKeyVaultName()}.vault.azure.net";
    }

    public async Task<string> GetSecretAsync(string key)
    {
        var client = CreateClient();
        var secret = await client.GetSecretAsync(key);

        return secret.Value.Value;
    }

    private string GetKeyVaultName()
    {
        var name = _configuration.GetValue<string?>(@"KeyVaultName", null);

        if (name is not null)
        {
            return name;
        }

        throw new InvalidOperationException(@"Could not find Key vault name.");
    }

    private SecretClient CreateClient()
    {
        var uri = new Uri(_keyVaultUri);
        var creds = new DefaultAzureCredential();

        return new(uri, creds);
    }
}

public static class AzureKeyVaultExtensions
{
    public static IServiceCollection AddAzureKeyVault(this IServiceCollection services)
    {
        return services.AddSingleton<ICloudSecretStore, AzureKeyVault>();
    }
}
