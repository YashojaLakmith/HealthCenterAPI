using Authentication.Abstractions.Services;
using Authentication.Repositories;
using Authentication.ValueObjects;

using Domain.Common;

namespace Authentication.Services;
internal sealed class TokenBasedPasswordResetService : ITokenBasedPasswordResetService
{
    private readonly IResetTokenStore _resetTokenStore;

    public TokenBasedPasswordResetService(IResetTokenStore resetTokenStore)
    {
        _resetTokenStore = resetTokenStore;
    }

    public Task<Result> ChangePasswordAsync(ResetToken passwordResetToken, Password newPassword, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
