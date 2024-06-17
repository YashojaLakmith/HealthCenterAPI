using Domain.Common;
using Domain.Primitives;

namespace Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    public string Value { get; }

    public static Result<PhoneNumber> CreatePhoneNumber(string phoneNumber)
    {
        if (!ValidatePhoneNumber(phoneNumber))
        {
            return Result<PhoneNumber>.Failure(new ArgumentException());
        }

        return new PhoneNumber(phoneNumber);
    }

    private static bool ValidatePhoneNumber(string number)
    {
        return false;
    }

    private PhoneNumber(string number)
    {
        Value = number;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
