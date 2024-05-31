namespace SecretStore.Abstractions;

public interface ICloudSecretStore
{
    Task<string> GetSecretAsync(string key);
}
