using Authentication.ValueObjects;

using Domain.Common;
using Domain.ValueObjects;

namespace Authentication.Abstractions.Services;
public interface IPasswordChangeService
{
    Task<Result> ChangeAdminPasswordWithResetTokenAsync(ResetToken resetToken, Password newPassword, CancellationToken cancellationToken = default);
}