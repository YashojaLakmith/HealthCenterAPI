using System.Security.Claims;

using Authentication.ValueObjects;

using Domain.Common;

namespace Authentication.Repositories;
public interface IResetTokenStore
{
    Task SetTokenAsync(ResetToken resetToken, byte[] serializedClaims, CancellationToken cancellationToken = default);

    Task<Result<IReadOnlyCollection<Claim>>> GetTokenClaimsAsync(ResetToken resetToken, CancellationToken tokenCancellationToken = default);

    Task RemoveTokenAsync(ResetToken resetToken, CancellationToken cancellationToken = default);
}
