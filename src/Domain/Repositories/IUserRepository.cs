using Domain.Common;
using Domain.Entities;
using Domain.Query;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface IUserRepository
{
    Task<Result<List<User>>> GetByFilteredQueryAsync(CustomQuery<User> customQuery, Pagination pagination, CancellationToken cancellationToken = default);

    Task<Result<User>> GetByIdAsync(Id userId, CancellationToken cancellationToken = default);

    Task<Result<bool>> IsEmailExistsAsync(EmailAddress registrationNumber, CancellationToken cancellationToken = default);

    Task<Result<User>> GetByEmailAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default);

    Task<Result> CreateNewAsync(User newUser,  CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(User user, CancellationToken cancellationToken = default);
}
