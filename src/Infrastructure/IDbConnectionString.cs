using Domain.Common;

namespace Infrastructure;

public interface IDbConnectionString
{
    Task<Result<string>> GetConnectionStringAsync(CancellationToken cancellationToken = default);
}
