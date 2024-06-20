using Authentication.Errors;

using Domain.Common;
using Domain.Primitives;

namespace Authentication.ValueObjects;
public sealed class Password : ValueObject
{
    internal const int MaxPasswordLength = 32;
    internal const int MinPasswordLength = 8;
    public string Value { get; }

    public static Result<Password> CreatePassword(string plainText)
    {
        var pwValidationResult = ValidatePassword(plainText);
        if (pwValidationResult.IsFailure)
        {
            return Result<Password>.Failure(pwValidationResult.Error);
        }

        return new Password(plainText);
    }

    private static Result ValidatePassword(string password)
    {
        return Result.Failure(PasswordValidationErrors.InvalidPasswordCharacterError);
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
