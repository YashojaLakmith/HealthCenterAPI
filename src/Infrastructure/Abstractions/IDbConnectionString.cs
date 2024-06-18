using Domain.Common;

namespace Infrastructure.Abstractions;

public interface IDbConnectionString
{
    Task<Result<string>> GetConnectionStringAsync(CancellationToken cancellationToken = default);
}
