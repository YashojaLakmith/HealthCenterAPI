﻿using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Repositories.RepositoryImplementations;
internal sealed class SessionRepository : ISessionRepository
{
    private readonly IApplicationDbContext _dbContext;

    public SessionRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<Session>> GetByIdAsync(Id sessionId, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Sessions
                                    .Include(session => session.Doctor)
                                    .Where(session => session.Id == sessionId)
                                    .FirstOrDefaultAsync(cancellationToken);

        return result ?? Result<Session>.Failure(RepositoryErrors.NotFoundError);
    }
}
