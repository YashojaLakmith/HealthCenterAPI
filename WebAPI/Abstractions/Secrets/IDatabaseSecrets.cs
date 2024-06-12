namespace WebAPI.Abstractions.Secrets;

public interface IDatabaseSecrets
{
    Task<string> GetDbConnectionStringAsync();
}
