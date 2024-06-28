using System.Security.Claims;
using Authentication.ValueObjects;
using Domain.Common;

namespace Authentication.Abstractions.Services;

public interface ISessionVerificationService
{
    Task<Result<IReadOnlyCollection<Claim>>> GetClaimsAsync(SessionToken sessionToken, CancellationToken cancellationToken = default);
    Task<Result> ExtendSessionAsync(SessionToken sessionToken, CancellationToken cancellationToken = default);
}