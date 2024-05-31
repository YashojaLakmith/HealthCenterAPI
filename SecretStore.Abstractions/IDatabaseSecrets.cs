namespace SecretStore.Abstractions;

public interface IDatabaseSecrets
{
    Task<string> GetDbConnectionStringAsync();
}
