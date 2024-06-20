using Authentication.Entities;
using Authentication.Repositories;
using Authentication.ValueObjects;

using Domain.Common;

namespace Authentication.Services;
public sealed class PasswordChangeService
{
    private readonly IResetTokenStore _resetTokenStore;

    public PasswordChangeService(IResetTokenStore resetTokenStore)
    {
        _resetTokenStore = resetTokenStore;
    }

    public Result ChangeAdminPassword(Credentials credentials, Password currentPassword, Password newPassword)
    {
        var authenticateService = new PasswordAuthenticationService();
        var authenticateResult = authenticateService.AuthenticateWithPassword(credentials, currentPassword);

        if (authenticateResult.IsFailure)
        {
            return authenticateResult;
        }

        SetNewPasswordAndSalt(newPassword, credentials);
        return Result.Success();
    }

    public async Task<Result> ChangeAdminPasswordWithResetTokenAsync(ResetToken resetToken, Credentials credentials, Password newPassword, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var tokenResult = await _resetTokenStore.GetTokenClaimsAsync(resetToken, cancellationToken);
        if (tokenResult.IsFailure)
        {
            return tokenResult;
        }

        await _resetTokenStore.RemoveTokenAsync(resetToken, cancellationToken);
        SetNewPasswordAndSalt(newPassword, credentials);
        return Result.Success();
    }

    private static void SetNewPasswordAndSalt(Password newPassword, Credentials credentials)
    {
        var newSalt = PasswordDerivation.DeriveNewSalt();
        var newHash = PasswordDerivation.DerivePassword(newPassword.Value, newSalt);

        credentials.Salt = newSalt;
        credentials.PasswordHash = newHash;
    }
}
