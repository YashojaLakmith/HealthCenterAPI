using System.Net.Mail;

using Domain.Common;
using Domain.Entities;
using Domain.Query;
using Domain.Repositories;
using Domain.ValueObjects;

using Infrastructure;

using Microsoft.EntityFrameworkCore;

using Repositories.CustomQueries;
using Repositories.Evaluators;

namespace Repositories;
internal class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result> CreateNewAsync(User newUser, CancellationToken cancellationToken = default)
    {
        await _dbContext.Users.AddAsync(newUser, cancellationToken);
        return Result.Success();
    }

    public Task<Result> DeleteAsync(User user, CancellationToken cancellationToken = default)
    {
        _dbContext.Users.Remove(user);
        return Task.FromResult(Result.Success());
    }

    public async Task<Result<User>> GetByEmailAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Users
                                .Where(user => user.EmailAddress == emailAddress)
                                .FirstOrDefaultAsync(cancellationToken);

        if(result is null)
        {
            return Result<User>.Failure(new Exception());
        }

        return result;
    }

    public async Task<Result<List<User>>> GetByFilteredQueryAsync(CustomQuery<User> customQuery, Pagination pagination, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
                                .AsNoTracking()
                                .EvaluateCustomQuery(customQuery)
                                .ApplyPagination(pagination)
                                .ToListAsync(cancellationToken);
    }

    public async Task<Result<User>> GetByIdAsync(Id userId, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Users
                                .Where(user => user.Id == userId)
                                .FirstOrDefaultAsync(cancellationToken);

        if (result is null)
        {
            return Result<User>.Failure(new Exception());
        }

        return result;
    }
}
