using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Repositories.Base;
public interface IUserWithEmailRepository
{
    Task<bool> IsEmailAlreadyExists(EmailAddress emailAddress, CancellationToken cancellationToken = default);
}
