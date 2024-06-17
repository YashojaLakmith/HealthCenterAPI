using Domain.Common;
using Domain.Primitives;

namespace Domain.ValueObjects;

public class Description : ValueObject
{
    public string Value { get; }

    public static Result<Description> CreateDescription(string descrptionStr)
    {
        if (!ValidateDescription(descrptionStr))
        {
            return Result<Description>.Failure(new ArgumentException());
        }

        return new Description(descrptionStr);
    }

    private static bool ValidateDescription(string description)
    {
        return false;
    }

    private Description(string description)
    {
        Value = description;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
