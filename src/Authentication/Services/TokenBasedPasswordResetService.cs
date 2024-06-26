using System.Security.Claims;
using Authentication.Abstractions.Services;
using Authentication.Errors;
using Authentication.Repositories;
using Authentication.ValueObjects;

using Domain.Common;
using Domain.ValueObjects;

namespace Authentication.Services;
internal sealed class TokenBasedPasswordResetService : ITokenBasedPasswordResetService
{
    private readonly IResetTokenStore _resetTokenStore;
    private readonly ICredentialRepository _credentialRepository;

    public TokenBasedPasswordResetService(IResetTokenStore resetTokenStore, ICredentialRepository credentialRepository)
    {
        _resetTokenStore = resetTokenStore;
        _credentialRepository = credentialRepository;
    }

    public async Task<Result> ChangePasswordAsync(ResetToken passwordResetToken, Password newPassword, CancellationToken cancellationToken = default)
    {
        var claimResult = await _resetTokenStore.GetTokenClaimsAsync(passwordResetToken, cancellationToken);
        if (claimResult.IsFailure)
        {
            return claimResult;
        }

        var deserializedClaims = await ClaimSerializer.DeserializeClaimsAsync(claimResult.Value, cancellationToken);
        var idResult = GetAdminIdFromClaims(deserializedClaims);
        if (idResult.IsFailure)
        {
            return idResult;
        }

        await _resetTokenStore.RemoveTokenAsync(passwordResetToken, cancellationToken);
        var credObjectResult = await _credentialRepository.GetCredentialObjectByIdAsync(idResult.Value, cancellationToken);
        return credObjectResult.IsFailure ? credObjectResult : credObjectResult.Value.ChangePassword(newPassword);
    }

    private static Result<Id> GetAdminIdFromClaims(IReadOnlyCollection<Claim> claims)
    {
        var idClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        return idClaim is null ? Result<Id>.Failure(TokenErrors.InvalidToken) : Id.CreateId(idClaim.Value);
    }
}
