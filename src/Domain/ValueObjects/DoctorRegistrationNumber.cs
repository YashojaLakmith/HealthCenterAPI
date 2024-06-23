using Domain.Common;
using Domain.Common.Errors;
using Domain.Primitives;

namespace Domain.ValueObjects;

public class DoctorRegistrationNumber : ValueObject
{
    private const int Length = 10;

    public string Value { get; }

    public static Result<DoctorRegistrationNumber> Create(string regNumberStr)
    {
        if(string.IsNullOrWhiteSpace(regNumberStr) || regNumberStr == string.Empty)
        {
            return Result<DoctorRegistrationNumber>.Failure(DoctorRegistrationNumberErrors.EmptyString);
        }

        if(regNumberStr.Length != Length)
        {
            return Result<DoctorRegistrationNumber>.Failure(DoctorRegistrationNumberErrors.InvalidLength);
        }

        if(!uint.TryParse(regNumberStr, out _))
        {
            return Result<DoctorRegistrationNumber>.Failure(DoctorRegistrationNumberErrors.InvalidCharacters);
        }

        return new DoctorRegistrationNumber(regNumberStr);
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
