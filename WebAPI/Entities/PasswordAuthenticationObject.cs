using System.Security.Claims;

using WebAPI.DataTransferObjects.Login;
using WebAPI.Helpers;

namespace WebAPI.Entities;

public class PasswordAuthenticationObject : IDisposable
{
    private readonly string _name;
    private readonly byte[] _passwordHash;
    private readonly byte[] _salt;
    private readonly Role _role;
    private bool disposedValue;

    public string UserId { get; }
    public DateTime? NewLoginTime { get; private set; }

    public static PasswordAuthenticationObject Create(string userId, string name, string password, string salt, Role role)
    {
        return new PasswordAuthenticationObject(userId, name, password, salt, role);
    }

    public virtual bool TryAuthenticate(LoginInformation loginInformation, out IEnumerable<Claim> claims)
    {
        if (!CanAuthenticate(loginInformation))
        {
            claims = [];
            return false;
        }

        claims =
            [
            new Claim(ClaimTypes.NameIdentifier, UserId),
            new Claim(ClaimTypes.Name, _name),
            new Claim(ClaimTypes.Role, _role.ToString())
            ];
        NewLoginTime = DateTime.UtcNow;
        return true;
    }

    private PasswordAuthenticationObject(string userId, string name, string password, string salt, Role role)
    {
        UserId = userId;
        _name = name;
        _role = role;
        _passwordHash = Convert.FromHexString(password);
        _salt = Convert.FromHexString(salt);
    }

    private bool CanAuthenticate(LoginInformation loginInformation)
    {
        var candidateHash = PasswordDerivation.DerivePassword(loginInformation.Password, _salt);
        var result = UserId.Equals(loginInformation.UserId, StringComparison.OrdinalIgnoreCase)
            && candidateHash.SequenceEqual(_passwordHash);

        Array.Clear(candidateHash);
        return result;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            Array.Clear(_passwordHash);
            Array.Clear(_salt);
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
