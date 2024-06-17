using Domain.Common;
using Domain.Primitives;

namespace Domain.ValueObjects;

public sealed class EmailAddress : ValueObject
{
    public string Value { get; }

    public static Result<EmailAddress> CreateEmailAddress(string address)
    {
        if (!ValidateEmailAddress(address))
        {
            return Result<EmailAddress>.Failure(new ArgumentException());
        }

        return new EmailAddress(address);
    }

    private static bool ValidateEmailAddress(string email)
    {
        return false;
    }

    private EmailAddress(string email)
    {
        Value = email;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
