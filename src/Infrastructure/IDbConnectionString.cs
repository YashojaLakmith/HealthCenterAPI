namespace Infrastructure;

public interface IDbConnectionString
{
    Task<string> GetConnectionStringAsync(CancellationToken cancellationToken = default);
}
