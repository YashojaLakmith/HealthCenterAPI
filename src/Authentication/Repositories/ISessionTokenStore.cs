using System.Security.Claims;

using Authentication.ValueObjects;

using Domain.Common;

namespace Authentication.Repositories;
public interface ISessionTokenStore
{
    Task<Result<byte[]>> GetAssociatedClaimsAsync(SessionToken sessionToken, CancellationToken cancellationToken = default);

    Task<Result> AddTokenAsync(SessionToken token, byte[] serializedClaims, CancellationToken cancellationToken = default);

    Task<Result> RefreshTokenAsync(SessionToken sessionToken, CancellationToken cancellationToken = default);

    Task<Result> RevokeTokenAsync(SessionToken sessionToken, CancellationToken cancellationToken = default);
}
