using Authentication.ValueObjects;

using Domain.Common;
using Domain.Entities;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Authentication.Entities;
public sealed class Credentials : Entity
{
    public Admin Admin { get; internal set; }
    public IReadOnlyCollection<byte> PasswordHash { get; internal set; }
    public IReadOnlyCollection<byte> Salt {  get; internal set; }   

    public static Result<Credentials> CreateCredentials(Id credentialId, Admin user, IReadOnlyCollection<byte> passwordHash, IReadOnlyCollection<byte> salt)
    {
        return new Credentials(credentialId, user, passwordHash, salt);
    }

    private Credentials(Id id, Admin admin, IReadOnlyCollection<byte> passwordHash, IReadOnlyCollection<byte> salt) : base(id)
    {
        Admin = admin;
        PasswordHash = passwordHash;
        Salt = salt;
    }

    public Result ChangePasswordAfterAuthenticating(Password currentPassword, Password newPassword)
    {
        throw new NotImplementedException();
    }

    public bool CanAuthenticateWithPassword(Password password)
    {
        throw new NotImplementedException();
    }

    public Result ChangePassword(Password newPassword)
    {
        throw new NotImplementedException();
    }
}
