using Authentication.Entities;

using Domain.Common;
using Domain.ValueObjects;

namespace Authentication.Repositories;
public interface IAuthServiceRepository
{
    Task<Result<Credentials>> GetCredentialObjectByIdAsync(Id userId, CancellationToken cancellationToken = default);

    Task<Result<Credentials>> GetCredentialObjectByEmailAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default);

    Task<Result> InsertNewAsync(Credentials credentials, CancellationToken cancellationToken = default);
}
