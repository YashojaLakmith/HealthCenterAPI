using Authentication.ValueObjects;

using Domain.Common;

namespace Authentication.Abstractions.Services;
public interface ITokenBasedPasswordResetService
{
    Task<Result> ChangePasswordAsync(ResetToken passwordResetToken, Password newPassword, CancellationToken cancellationToken = default);
}