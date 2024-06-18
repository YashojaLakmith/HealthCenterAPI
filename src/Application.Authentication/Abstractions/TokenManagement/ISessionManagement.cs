using System.Security.Claims;

using Authentication.ValueObjects;

using Domain.Common;

namespace Application.Authentication.Abstractions.TokenManagement;
public interface ISessionManagement
{
    Task<Result<SessionToken>> CreateSessionAsync(IEnumerable<Claim> claims, CancellationToken cancellationToken = default);

    Task<Result<IEnumerable<Claim>>> GetClaimsAsync(SessionToken token, CancellationToken cancellationToken = default);

    Task<Result> RefreshSessionAsync(SessionToken sessionToken, CancellationToken cancellationToken = default);

    Task<Result> RevokeSessionAsync(SessionToken sessionToken, CancellationToken cancellationToken = default);
}
