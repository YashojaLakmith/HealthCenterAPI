using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface IUserRepository
{
    Task<Result<List<User>>> GetByFilteredQueryAsync(Pagination pagination, CancellationToken cancellationToken = default);

    Task<Result<User>> GetByIdAsync(Id userId, CancellationToken cancellationToken = default);

    Task<Result<User>> GetByEmailAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default);

    Task<Result> CreateNewAsync(User newUser,  CancellationToken cancellationToken = default);

    Task<Result> ModifyAsync(User user, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(Id userId, CancellationToken cancellationToken = default);

    Task<Result<bool>> ExistsByIdAsync(Id userId, CancellationToken cancellationToken = default);

    Task<Result<bool>> ExistsByEmailAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default);
}
