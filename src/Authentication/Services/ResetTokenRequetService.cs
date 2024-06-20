﻿using Authentication.Abstractions.Services;
using Authentication.Repositories;
using Authentication.ValueObjects;

using Domain.Common;
using Domain.ValueObjects;

namespace Authentication.Services;
public class ResetTokenRequetService : IResetTokenRequetService
{
    private readonly IResetTokenStore _resetTokenStore;
    private readonly IAuthServiceRepository _credentialRespository;

    public ResetTokenRequetService(IResetTokenStore resetTokenStore, IAuthServiceRepository credentialRespository)
    {
        _resetTokenStore = resetTokenStore;
        _credentialRespository = credentialRespository;
    }

    public async Task<Result<ResetToken>> RequestResetTokenAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        var credentials = await _credentialRespository.GetCredentialObjectByEmailAsync(emailAddress, cancellationToken);
        if (credentials.IsFailure)
        {
            return Result<ResetToken>.Failure(credentials.Error);
        }

        var resetToken = ResetToken.CreateToken();
        var claims = ClaimExtractor.ExtractClaims(credentials.Value);
        var serializedClaims = await ClaimSerializer.SerializeClaimsAsync(claims, cancellationToken);

        await _resetTokenStore.SetTokenAsync(resetToken, serializedClaims, cancellationToken);

        return resetToken;
    }
}
