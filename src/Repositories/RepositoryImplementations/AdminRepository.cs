using Domain.Common;
using Domain.Entities;
using Domain.Enum;
using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Repositories.RepositoryImplementations;
internal sealed class AdminRepository : IAdminRepository
{
    private readonly IApplicationDbContext _dbContext;

    public AdminRepository(IApplicationDbContext dbContext)
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

    public async Task<Result<Role>> GetRolesAsync(Id invokerId, CancellationToken cancellationToken)
    {
        var resultSet = await _dbContext.Users
            .AsNoTracking()
            .Where(admin => admin.Id == invokerId)
            .Select(admin => admin.Role)
            .FirstOrDefaultAsync(cancellationToken);

        return resultSet == default ? Result<Role>.Failure(RepositoryErrors.NotFoundError) : resultSet;
    }

    public async Task<bool> IsPhoneNumberExistsAsync(PhoneNumber newPhoneNumber, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(admin => admin.PhoneNumber == newPhoneNumber, cancellationToken);
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

    public async Task<bool> IsEmailExistsAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
                                .AsNoTracking()
                                .AnyAsync(user => user.EmailAddress == emailAddress, cancellationToken);
    }
}
