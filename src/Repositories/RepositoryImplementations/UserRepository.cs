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
internal class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext _dbContext;

    public UserRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result> CreateNewAsync(Admin newUser, CancellationToken cancellationToken = default)
    {
        await _dbContext.Users.AddAsync(newUser, cancellationToken);
        return Result.Success();
    }

    public Task<Result> DeleteAsync(Admin user, CancellationToken cancellationToken = default)
    {
        _dbContext.Users.Remove(user);
        return Task.FromResult(Result.Success());
    }

    public async Task<Result<Admin>> GetByEmailAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Users
                                .Where(user => user.EmailAddress == emailAddress)
                                .FirstOrDefaultAsync(cancellationToken);

        if (result is null)
        {
            return Result<Admin>.Failure(RepositoryErrors.NotFoundError);
        }

        return result;
    }

    public async Task<Result<List<Admin>>> GetByFilteredQueryAsync(CustomQuery<Admin> customQuery, Pagination pagination, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
                                .AsNoTracking()
                                .EvaluateCustomQuery(customQuery)
                                .ApplyPagination(pagination)
                                .ToListAsync(cancellationToken);
    }

    public async Task<Result<Admin>> GetByIdAsync(Id userId, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Users
                                .Where(user => user.Id == userId)
                                .FirstOrDefaultAsync(cancellationToken);

        if (result is null)
        {
            return Result<Admin>.Failure(RepositoryErrors.NotFoundError);
        }

        return result;
    }

    public async Task<Result<bool>> IsEmailExistsAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
                                .AsNoTracking()
                                .AnyAsync(user => user.EmailAddress == emailAddress, cancellationToken);
    }
}
