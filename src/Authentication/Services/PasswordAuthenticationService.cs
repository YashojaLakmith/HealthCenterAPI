using Authentication.Abstractions.Services;
using Authentication.ValueObjects;
using Domain.Common;
using Domain.ValueObjects;

namespace Authentication.Services;

public class PasswordAuthenticationService : IPasswordAuthenticationService
{
    public async Task<Result<SessionToken>> AuthenticateWithPasswordAsync(
        EmailAddress emailAddress,
        Password password,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}