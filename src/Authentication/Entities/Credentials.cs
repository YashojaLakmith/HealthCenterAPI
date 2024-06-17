using System.Security.Cryptography;

using Authentication.Services;
using Authentication.ValueObjects;

using Domain.Common;
using Domain.Entities;
using Domain.Primitives;

namespace Authentication.Entities;
public sealed class Credentials : Entity, IDisposable
{
    private const int Iterations = 100000;
    private const int HashBitLength = 256;
    private const int SaltBitLength = 256;

    private byte[] _passwordHash;
    private byte[] _salt;

    public User User { get; private set; }
    public IReadOnlyCollection<byte> PasswordHash => _passwordHash;
    public IReadOnlyCollection<byte> Salt => _salt;

    public bool CanValidatePassword(Password password)
    {
        var challengePassword = PasswordDerivation.DerivePassword(password.Value, _salt, HashBitLength, Iterations);
        return challengePassword.SequenceEqual(_passwordHash);
    }

    public void ChangePassword(Password newPassword)
    {
        _salt = RandomNumberGenerator.GetBytes(SaltBitLength / 8);
        _passwordHash = PasswordDerivation.DerivePassword(newPassword.Value, _salt, HashBitLength, Iterations);
        UpdateTimeStamp();   
    }

    public static Result<Credentials> CreateCredentials(User user, IEnumerable<byte> passwordHash, IEnumerable<byte> salt, Guid timeStamp)
    {
        return new Credentials(user, passwordHash, salt, timeStamp);
    }

    public static Result<Credentials> CreateCredentials(User user)
    {
        var pw = RandomNumberGenerator.GetBytes(HashBitLength / 8);
        var pwString = Convert.ToHexString(pw);
        var salt = RandomNumberGenerator.GetBytes(SaltBitLength / 8);
        var hash = PasswordDerivation.DerivePassword(pwString, salt, HashBitLength, Iterations);

        Array.Clear(pw);
        return new Credentials(user, hash, salt, Guid.NewGuid());
    }

    public void Dispose()
    {
        Array.Clear(_passwordHash);
        Array.Clear(_salt);
    }

    private Credentials(User user, IEnumerable<byte> passwordHash, IEnumerable<byte> salt, Guid timeStamp)
    {
        User = user;
        _passwordHash = passwordHash.ToArray();
        _salt = salt.ToArray();
        TimeStamp = timeStamp;
    }
}
