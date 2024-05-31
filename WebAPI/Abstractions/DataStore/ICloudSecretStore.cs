namespace WebAPI.Abstractions.DataStore;

public interface ICloudSecretStore
{
    Task<string> GetJwtSigningKeyAsync();
    Task<string> GetDbConnectionStringAsync();
}
