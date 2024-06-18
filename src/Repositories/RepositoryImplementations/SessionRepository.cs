using Domain.Common;
using Domain.Entities;
using Domain.Query;
using Domain.Repositories;
using Domain.ValueObjects;

using Infrastructure.Abstractions;

using Microsoft.EntityFrameworkCore;

using Repositories.CustomQueries;
using Repositories.Evaluators;

namespace Repositories.RepositoryImplementations;
internal class SessionRepository : ISessionRepository
{
    private readonly IApplicationDbContext _dbContext;

    public SessionRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Result> DeleteAsync(Session session, CancellationToken cancellationToken = default)
    {
        _dbContext.Sessions.Remove(session);
        return Task.FromResult(Result.Success());
    }

    public async Task<Result<List<Session>>> GetByFilteredQueryAsync(CustomQuery<Session> customQuery, Pagination pagination, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Sessions
                                .AsNoTracking()
                                .EvaluateCustomQuery(customQuery)
                                .ApplyPagination(pagination)
                                .ToListAsync(cancellationToken);
    }

    public async Task<Result<Session>> GetByIdAsync(Id sessionId, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Sessions
                                    .Include(session => session.Appointments)
                                    .Include(session => session.Doctor)
                                    .Where(session => session.Id == sessionId)
                                    .FirstOrDefaultAsync(cancellationToken);

        if (result is null)
        {
            return Result<Session>.Failure(new Exception());
        }

        return result;
    }

    public async Task<Result> InsertNewAsync(Session newSession, CancellationToken cancellationToken = default)
    {
        await _dbContext.Sessions.AddAsync(newSession, cancellationToken);
        return Result.Success();
    }
}
