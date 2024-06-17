using System.Security.Claims;

using Domain.Common;

namespace Application.Abstractions.SessionManagement;
public interface ISessionManagement 
{
    Task<Result<string>> CreateSessionAsync(IEnumerable<Claim> claims, CancellationToken cancellationToken = default);

    Task<Result<IEnumerable<Claim>>> GetClaimsAsync(string token,  CancellationToken cancellationToken = default);

    Task<Result> RefreshSessionAsync(string sessionToken,  CancellationToken cancellationToken = default);

    Task<Result> RevokeSessionAsync(string sessionToken, CancellationToken cancellationToken = default);
}
