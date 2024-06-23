using Domain.Common;

namespace Domain.Repositories;
public interface IUnitOfWork
{
    Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default);
}
