using Domain.Common;
using Domain.Primitives;

namespace Domain.ValueObjects;

public class DoctorRegistrationNumber : ValueObject
{
    public string Value { get; }

    public static Result<DoctorRegistrationNumber> Create(string regNumberStr)
    {
        if (!ValidateRegistrationNumber(regNumberStr))
        {
            return Result<DoctorRegistrationNumber>.Failure(new ArgumentException());
        }

        return new DoctorRegistrationNumber(regNumberStr);
    }

    private static bool ValidateRegistrationNumber(string registrationNumber)
    {
        return false;
    }

    private DoctorRegistrationNumber(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
