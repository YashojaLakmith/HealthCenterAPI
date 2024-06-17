using Domain.Common;
using Domain.Primitives;

namespace Domain.ValueObjects;
public class Ward : ValueObject
{
    public string Value { get; }

    private Ward() : base() { }

    public static Result<Ward> CreateWard(string value)
    {
        if (!ValidateString(value))
        {
            return Result<Ward>.Failure(new Exception());
        }

        return new Ward(value);
    }

    private static bool ValidateString(string value)
    {
        return false;
    }

    private Ward(string value) : base()
    {
        Value = value;
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
