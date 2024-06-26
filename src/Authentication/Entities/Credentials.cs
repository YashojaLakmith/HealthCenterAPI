using Authentication.Errors;
using Authentication.Services;
using Authentication.ValueObjects;

using Domain.Common;
using Domain.Entities;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Authentication.Entities;
public sealed class Credentials : Entity
{
    private byte[] _passwordHash;
    private byte[] _salt;
    
    public Admin Admin { get; private init; }

    public IEnumerable<byte> PasswordHash
    {
        get => _passwordHash;
        private init => _passwordHash = value.ToArray();
    }

    public IEnumerable<byte> Salt
    {
        get => _salt;
        private init => _salt = value.ToArray();
    }   

    public static Credentials CreateCredentials(Admin admin)
    {
        var salt = PasswordDerivation.DeriveNewSalt();
        var passwordStr = PasswordDerivation.DeriveRandomPasswordString();
        var hash = PasswordDerivation.DerivePassword(passwordStr, salt);

        return new Credentials(Id.CreateId(), admin, hash, salt);
    }

    private Credentials(Id id, Admin admin, IReadOnlyCollection<byte> passwordHash, IReadOnlyCollection<byte> salt) : base(id)
    {
        Admin = admin;
        PasswordHash = passwordHash;
        Salt = salt;
    }

    public Result ChangePasswordAfterAuthenticating(Password currentPassword, Password newPassword)
    {
        if (!CanAuthenticateWithPassword(currentPassword))
        {
            return Result.Failure(AuthenticationErrors.PasswordAuthenticationFailedError);
        }

        ChangePassword(newPassword);
        return Result.Success();
    }

    public bool CanAuthenticateWithPassword(Password password)
    {
        var challengeHash = PasswordDerivation.DerivePassword(password.Value, Salt.ToArray());
        return challengeHash.SequenceEqual(PasswordHash);
    }

    public Result ChangePassword(Password newPassword)
    {
        var newSalt = PasswordDerivation.DeriveNewSalt();
        _passwordHash = PasswordDerivation.DerivePassword(newPassword.Value, newSalt);
        _salt = newSalt;
        
        return Result.Success();
    }
    
    private Credentials(){}
}
