using Domain.Common;
using Domain.Common.Errors;
using Domain.Primitives;

namespace Domain.ValueObjects;

public class Description : ValueObject
{
    private const int MaxCharacterLength = 500;

    public string Value { get; }

    public static Result<Description> CreateDescription(string descrptionStr)
    {
        if(string.IsNullOrWhiteSpace(descrptionStr) || descrptionStr == string.Empty)
        {
            return Result<Description>.Failure(DescriptionErrors.DescriptionIsEmpty);
        }

        if(descrptionStr.Length > MaxCharacterLength)
        {
            return Result<Description>.Failure(DescriptionErrors.ExceedsCharacterLength);
        }

        return new Description(descrptionStr);
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
