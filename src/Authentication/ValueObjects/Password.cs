using Domain.Common;
using Domain.Primitives;

namespace Authentication.ValueObjects;
public sealed class Password : ValueObject
{
    private const int MaxPasswordLength = 32;
    private const int MinPasswordLength = 8;
    public string Value { get; }

    public static Result<Password> CreatePassword(string plainText)
    {
        if (!ValidatePassword(plainText))
        {
            return Result<Password>.Failure(new ArgumentException());
        }

        return new Password(plainText);
    }

    private static bool ValidatePassword(string password)
    {
        return false;
    }

    private Password(string plainText)
    {
        Value = plainText;
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
