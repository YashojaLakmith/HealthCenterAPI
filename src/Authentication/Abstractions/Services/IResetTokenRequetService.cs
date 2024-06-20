using Authentication.ValueObjects;

using Domain.Common;
using Domain.ValueObjects;

namespace Authentication.Abstractions.Services;
public interface IResetTokenRequetService
{
    Task<Result<ResetToken>> RequestResetTokenAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default);
}