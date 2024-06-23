using Domain.Common;
using Domain.Common.Errors;
using Domain.Primitives;

namespace Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    private const int Length = 10;

    public string Value { get; }

    public static Result<PhoneNumber> CreatePhoneNumber(string phoneNumber)
    {
        if(string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber == string.Empty)
        {
            return Result<PhoneNumber>.Failure(PhoneNumberErrors.EmptyPhoneNumber);
        }

        if(phoneNumber.Length != Length)
        {
            return Result<PhoneNumber>.Failure(PhoneNumberErrors.InvalidLength);
        }

        if(!ulong.TryParse(phoneNumber, out _))
        {
            return Result<PhoneNumber>.Failure(PhoneNumberErrors.InvalidCharacters);
        }

        return new PhoneNumber(phoneNumber);
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
