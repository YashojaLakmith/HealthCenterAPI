using Domain.Common;
using Domain.Common.Errors;
using Domain.Primitives;

namespace Domain.ValueObjects;

public sealed class DateOfBirth : ValueObject
{
    public DateTime Value { get; }

    private DateOfBirth(DateTime value)
    {
        Value = value;
    }

    public static Result<DateOfBirth> Create(DateTime dob)
    {
        if (IsAgeLessThan16Years(dob))
        {
            return Result<DateOfBirth>.Failure(DateOfBirthErrors.AgeIsLowerThan16Years);
        }

        return new DateOfBirth(dob);
    }

    private static bool IsAgeLessThan16Years(DateTime dateOfBirth)
    {
        var now = DateTime.UtcNow;
        var dobMonths = (dateOfBirth.Year * 12) + dateOfBirth.Month;
        var nowMonths = (now.Year * 12) + now.Month;

        return (nowMonths - dobMonths) < (16 * 12);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
