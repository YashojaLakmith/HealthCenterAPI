namespace WebAPI.Abstractions.Secrets;

public interface IJwtSecrets
{
    Task<byte[]> GetJwtSigningKeyAsync();
}
