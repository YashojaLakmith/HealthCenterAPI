using Authentication.Entities;

using Domain.Common;
using Domain.ValueObjects;

namespace Authentication.Repositories;
public interface IAuthServiceRepository
{
    Task<Result<Credentials>> GetCredentialObjectAsync(Id userId, CancellationToken cancellationToken);
    Task<Result> InsertNewAsync(Credentials credentials, CancellationToken cancellationToken = default);
    Task<Result> SaveChangesAsync(Credentials credentials, CancellationToken cancellationToken);
}
