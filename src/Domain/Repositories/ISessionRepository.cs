using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface ISessionRepository
{
    Task<Result<List<Session>>> GetByFilteredQueryAsync(Pagination pagination, CancellationToken cancellationToken = default);

    Task<Result<Session>> GetByIdAsync(Id sessionId, CancellationToken cancellationToken = default);

    Task<Result> InsertNewAsync(Session newSession, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(Id sessionId, CancellationToken cancellationToken = default);

    Task<Result> ModifyAsync(Session session, CancellationToken cancellationToken = default);

    Task<Result<bool>> ExistsAsync(Id sessionId, CancellationToken cancellationToken = default);
}
