namespace WebAPI.Abstractions.Secrets;

public interface IUserSecrets
{
    Task<byte[]> GetJwtSigningKeyAsync();
    Task<string> GetDbConnectionStringAsync();
}
