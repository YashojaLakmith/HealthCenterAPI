using System.Security.Cryptography;

using Domain.Common;
using Domain.Primitives;

namespace Authentication.ValueObjects;
public class ResetToken : ValueObject
{
    private const int ResetTokenBitLength = 256;
    public string Value { get; }

    public static Result<ResetToken> CreateToken(string tokenString)
    {
        return new ResetToken(tokenString);
    }

    public static ResetToken CreateToken()
    {
        var rand =  RandomNumberGenerator.GetHexString(ResetTokenBitLength / 8 * 2);
        return new ResetToken(rand);
    }

    private ResetToken(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
