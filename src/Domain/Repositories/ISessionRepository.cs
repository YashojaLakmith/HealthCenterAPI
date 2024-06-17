using Domain.Common;
using Domain.Entities;
using Domain.Query;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface ISessionRepository
{
    Task<Result<List<Session>>> GetByFilteredQueryAsync(CustomQuery<Session> customQuery, Pagination pagination, CancellationToken cancellationToken = default);

    Task<Result<Session>> GetByIdAsync(Id sessionId, CancellationToken cancellationToken = default);

    Task<Result> InsertNewAsync(Session newSession, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(Session session, CancellationToken cancellationToken = default);
}
