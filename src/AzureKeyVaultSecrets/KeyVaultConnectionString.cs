using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

using Infrastructure.Abstractions;

using Microsoft.Extensions.Configuration;

namespace AzureKeyVaultSecrets;

internal class KeyVaultConnectionString : IDbConnectionStringSource
{
    private readonly string _keyName;
    private readonly string _vaultName;
    private readonly IConfiguration _configuration;

    public KeyVaultConnectionString(IConfiguration configuration)
    {
        _configuration = configuration;
        (_vaultName, _keyName) = GetKeyVaultAndKey();
    }

    public string GetConnectionString()
    {
        var secretClient = CreateSecretClient();
        var secret = secretClient.GetSecret(_keyName);
        return secret.Value.Value;
    }

    public async Task<string> GetConnectionStringAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var client = CreateSecretClient();
        var secret = await client.GetSecretAsync(_keyName, cancellationToken: cancellationToken);
        return secret.Value.Value;
    }

    private SecretClient CreateSecretClient()
    {
        var uri = $@"https://{_vaultName}.vault.azure.net";
        return new SecretClient(new Uri(uri), new DefaultAzureCredential());
    }

    private (string kvName, string key) GetKeyVaultAndKey()
    {
        var section = _configuration.GetRequiredSection(@"AzKeyVault");
        var kvName = section[@"Name"];
        var key = section[@"DbKeyName"];

        if(kvName is null || key is null)
        {
            throw new InvalidOperationException(@"Key name or key vault name is not found");
        }

        return (kvName, key);
    }
}
