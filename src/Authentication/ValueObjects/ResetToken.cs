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

    private ResetToken(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
