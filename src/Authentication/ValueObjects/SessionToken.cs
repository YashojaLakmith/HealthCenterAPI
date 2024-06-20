using System.Security.Cryptography;

using Domain.Common;
using Domain.Primitives;

namespace Authentication.ValueObjects;
public class SessionToken : ValueObject
{
    private const int TokenByteLength = 64;
    public string Value { get; }

    public static Result<SessionToken> CreateToken(string value)
    {
        return new SessionToken(value);
    }

    public static SessionToken CreateToken()
    {
        var token = RandomNumberGenerator.GetHexString(TokenByteLength * 2);
        return new SessionToken(token);
    }

    private SessionToken(string s)
    {
        Value = s;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
