using Application.CustomFilters;
using Application.Session.Views;
using Domain.Common;
using Domain.ValueObjects;

namespace Application.Abstractions.ReadOnlyRepositories;

public interface IReadOnlySessionRepository
{
    Task<Result<SessionDetailView>> GetSessionDetailViewAsync(
        Id sessionId,
        CancellationToken cancellationToken = default);

    Task<Result<IReadOnlyCollection<SessionListItemView>>> GetSessionListAsync(
        SessionFilter filter,
        CancellationToken cancellationToken = default);
    
    Task<Result<IReadOnlyCollection<SessionListItemView>>> GetSessionListAsync(
        SessionFilterByDoctorId filter,
        CancellationToken cancellationToken = default);
}