using Domain.Common;
using Domain.Entities;
using Domain.Query;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface IUserRepository
{
    Task<Result<List<Admin>>> GetByFilteredQueryAsync(CustomQuery<Admin> customQuery, Pagination pagination, CancellationToken cancellationToken = default);

    Task<Result<Admin>> GetByIdAsync(Id userId, CancellationToken cancellationToken = default);

    Task<Result<bool>> IsEmailExistsAsync(EmailAddress registrationNumber, CancellationToken cancellationToken = default);

    Task<Result<Admin>> GetByEmailAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default);

    Task<Result> CreateNewAsync(Admin newUser,  CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(Admin user, CancellationToken cancellationToken = default);
}
