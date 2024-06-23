namespace Infrastructure.Abstractions;

public interface IDbConnectionStringSource
{
    Task<string> GetConnectionStringAsync(CancellationToken cancellationToken = default);

    string GetConnectionString();
}
