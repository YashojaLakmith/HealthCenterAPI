using Domain.Common;
using Domain.Entities;
using Domain.Enum;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface IAdminRepository
{
    Task<Result<Admin>> GetByIdAsync(Id userId, CancellationToken cancellationToken = default);

    Task<bool> IsEmailExistsAsync(EmailAddress registrationNumber, CancellationToken cancellationToken = default);

    Task<Result<Admin>> GetByEmailAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default);

    Task<Result> CreateNewAsync(Admin newUser,  CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(Admin user, CancellationToken cancellationToken = default);

    Task<Result<Role>> GetRolesAsync(Id invokerId, CancellationToken cancellationToken);

    Task<bool> IsPhoneNumberExistsAsync(PhoneNumber newPhoneNumber, CancellationToken cancellationToken);
}
