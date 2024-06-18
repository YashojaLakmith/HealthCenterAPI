using System.Security.Claims;

using Authentication.Entities;
using Authentication.ValueObjects;

using Domain.Common;

namespace Application.Authentication.Abstractions.TokenManagement;
public interface IResetTokenManagement
{
    Task<Result<ResetToken>> CreateNewResetTokenAsync(Credentials credentials, CancellationToken cancellationToken = default);

    Task<Result<IEnumerable<Claim>>> VerifyResetTokenAsync(ResetToken resetToken, CancellationToken cancellationToken = default);

    Task<Result> RemoveTokenAsync(ResetToken resetToken, CancellationToken cancellationToken = default);
}
