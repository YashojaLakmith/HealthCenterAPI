using System.Security.Claims;

using Authentication.ValueObjects;

using Domain.Common;

namespace Authentication.Repositories;
public interface IResetTokenStore
{
    Task SetTokenAsync(ResetToken resetToken, byte[] serializedClaims, CancellationToken cancellationToken = default);

    Task<Result<byte[]>> GetTokenClaimsAsync(ResetToken resetToken, CancellationToken cancellationToken = default);

    Task RemoveTokenAsync(ResetToken resetToken, CancellationToken cancellationToken = default);
}
