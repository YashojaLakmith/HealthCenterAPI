namespace WebAPI.Abstractions.Secrets;

public interface ICloudSecretStore
{
    Task<string> GetSecretAsync(string key);
}
