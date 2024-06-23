using Authentication.ValueObjects;

using Domain.Common;
using Domain.ValueObjects;

namespace Authentication.Abstractions.Services;
public interface IPasswordAuthenticationService
{
    Task<Result<SessionToken>> AuthenticateWithPasswordAsync(EmailAddress emailAddress, Password password, CancellationToken cancellationToken = default);
}