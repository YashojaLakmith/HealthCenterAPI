using Authentication.Entities;
using Authentication.Errors;
using Authentication.ValueObjects;

using Domain.Common;

namespace Authentication.Services;
public sealed class PasswordAuthenticationService
{
    public Result AuthenticateWithPassword(Credentials credentials, Password password)
    {
        var challengePwBytes = PasswordDerivation.DerivePassword(password.Value, [.. credentials.Salt]);

        return challengePwBytes.SequenceEqual(credentials.PasswordHash) ? Result.Success() : Result.Failure(AuthenticationErrors.PasswordAuthenticationFailedError);
    }
}
