using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

using Domain.Common;

using Infrastructure;

namespace AzureKeyVaultSecrets;

public sealed class KeyVaultConnectionString : IDbConnectionString
{
    private const string KeyName = "Db_HealthCenterAPI";
    private const string VaultName = "HealthCenterAPI";
    private const string KvUri = $@"https://{VaultName}.vault.azure.net";
    public async Task<Result<string>> GetConnectionStringAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();
            var client = CreateSecretClient();
            var secret = await client.GetSecretAsync(KeyName, cancellationToken: cancellationToken);
            return Result<string>.Success(secret.Value.Value);
        }
        catch(Exception ex)
        {
            return Result<string>.Failure(ex);
        }
    }

    private static SecretClient CreateSecretClient()
    {
        return new SecretClient(new Uri(KvUri), new DefaultAzureCredential());
    }
}
