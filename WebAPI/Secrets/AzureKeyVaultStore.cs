using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

using WebAPI.Abstractions.DataStore;

namespace WebAPI.Secrets;

public class AzureKeyVaultStore : ICloudSecretStore
{
    private readonly IConfiguration _configuration;
    private readonly string _keyVaultUri;

    public AzureKeyVaultStore(IConfiguration configuration)
    {
        _configuration = configuration;
        _keyVaultUri = $@"https://{GetKeyVaultName()}.vault.azure.net";
    }

    public async Task<string> GetDbConnectionStringAsync()
    {
        return await GetSecretAsync(SecretKeyNames.DBKey);
    }

    public async Task<string> GetJwtSigningKeyAsync()
    {
        return await GetSecretAsync(SecretKeyNames.JwtKey);
    }

    private string GetKeyVaultName()
    {
        var name = _configuration.GetValue<string?>(@"KeyVaultName", null);

        if(name is not null)
        {
            return name;
        }

        throw new InvalidOperationException(@"Could not find Key vault name.");
    }

    private async Task<string> GetSecretAsync(string key)
    {
        var client = CreateClient();
        var secret = await client.GetSecretAsync(key);

        return secret.Value.Value;
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
        return services.AddSingleton<ICloudSecretStore, AzureKeyVaultStore>();
    }
}
