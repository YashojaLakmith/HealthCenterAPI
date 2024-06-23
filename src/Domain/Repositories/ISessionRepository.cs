using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface ISessionRepository
{
    Task<Result<Session>> GetByIdAsync(Id sessionId, CancellationToken cancellationToken = default);
}
