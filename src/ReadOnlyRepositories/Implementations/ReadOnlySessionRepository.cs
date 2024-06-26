using Application.Abstractions.ReadOnlyRepositories;
using Application.CustomFilters;
using Application.Session.Views;
using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using ReadOnlyRepositories.Evaluators;
using ReadOnlyRepositories.Extensions;

namespace ReadOnlyRepositories.Implementations;

internal sealed class ReadOnlySessionRepository : IReadOnlySessionRepository
{
    private readonly IApplicationDbContext _dbContext;

    public ReadOnlySessionRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<SessionDetailView>> GetSessionDetailViewAsync(
        Id sessionId,
        CancellationToken cancellationToken = default)
    {
        var queryResult = await _dbContext.Sessions
            .AsNoTracking()
            .Include(session => session.Doctor)
            .Where(session => session.Id == sessionId)
            .Select(session => session.AsDetailView())
            .FirstOrDefaultAsync(cancellationToken);

        return queryResult ?? Result<SessionDetailView>.Failure(RepositoryErrors.NotFoundError);
    }

    public async Task<Result<IReadOnlyCollection<SessionListItemView>>> GetSessionListAsync(
        SessionFilter filter,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Sessions
            .AsNoTracking()
            .Include(session => session.Doctor)
            .EvaluateFilter(filter)
            .Select(session => session.AsListItem())
            .ToListAsync(cancellationToken);
    }

    public async Task<Result<IReadOnlyCollection<SessionListItemView>>> GetSessionListAsync(
        SessionFilterByDoctorId filter,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Sessions
            .AsNoTracking()
            .Include(session => session.Doctor)
            .EvaluateFilter(filter)
            .Select(session => session.AsListItem())
            .ToListAsync(cancellationToken);
    }
}