using Authentication.Entities;

using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Authentication.Services;
public class DefaultCredentialService
{
    public Result<Credentials> CreateDefaultCredentials(Admin admin)
    {
        var str = PasswordDerivation.DeriveRandomPasswordString();
        var salt = PasswordDerivation.DeriveNewSalt();
        var pwHash = PasswordDerivation.DerivePassword(str, salt);

        return Credentials.CreateCredentials(Id.CreateId(), admin, pwHash, salt);
    }
}
