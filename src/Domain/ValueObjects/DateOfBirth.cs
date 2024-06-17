using Domain.Common;
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
        var current = DateTime.Now;
        if(dob >= current)
        {
            return Result<DateOfBirth>.Failure(new ArgumentException());
        }

        return new DateOfBirth(current);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
