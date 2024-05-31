namespace SecretStore.Abstractions;

public interface IJwtSecrets
{
    Task<byte[]> GetJwtSigningKeyAsync();
}
