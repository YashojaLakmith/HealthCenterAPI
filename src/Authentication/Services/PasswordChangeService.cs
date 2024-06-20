using System.Security.Claims;
using Authentication.Abstractions.Services;
using Authentication.Errors;
using Authentication.Repositories;
using Authentication.ValueObjects;

using Domain.Common;
using Domain.ValueObjects;

namespace Authentication.Services;
public sealed class PasswordChangeService : IPasswordChangeService
{
    private readonly IResetTokenStore _resetTokenStore;
    private readonly IAuthServiceRepository _credentialRepository;

    public PasswordChangeService(IResetTokenStore resetTokenStore, IAuthServiceRepository credentialRepository)
    {
        _resetTokenStore = resetTokenStore;
        _credentialRepository = credentialRepository;
    }

    public async Task<Result> ChangeAdminPasswordWithResetTokenAsync(ResetToken resetToken, Password newPassword, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var tokenResult = await _resetTokenStore.GetTokenClaimsAsync(resetToken, cancellationToken);
        if (tokenResult.IsFailure)
        {
            return tokenResult;
        }

        await _resetTokenStore.RemoveTokenAsync(resetToken, cancellationToken);

        var nameIdClaim = tokenResult.Value.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
        if (nameIdClaim is null)
        {
            return Result.Failure(ClaimErrors.CouldNotProvideIdentity);
        }

        var idResult = Id.CreateId(nameIdClaim.Value);
        if (idResult.IsFailure)
        {
            return idResult;
        }

        var credentialResult = await _credentialRepository.GetCredentialObjectByIdAsync(idResult.Value, cancellationToken);
        if (credentialResult.IsFailure)
        {
            return credentialResult;
        }

        credentialResult.Value.ChangePassword(newPassword);
        return Result.Success();
    }
}
