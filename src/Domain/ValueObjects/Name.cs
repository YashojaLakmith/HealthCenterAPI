using Domain.Common;
using Domain.Common.Errors;
using Domain.Primitives;

namespace Domain.ValueObjects;

public sealed class Name : ValueObject
{
    public const int MaxNameLength = 100;
    public const int MinNameLength = 3;

    public string Value { get; }

    private Name(string name)
    {
        Value = name;
    }

    public static Result<Name> Create(string name)
    {
        if(string.IsNullOrWhiteSpace(name) || name == string.Empty)
        {
            return Result<Name>.Failure(NameErrors.EmptyName);
        }

        if (name.Length > MaxNameLength)
        {
            return Result<Name>.Failure(NameErrors.ExceedsMaximumCharacters);
        }

        if(name.Length < MinNameLength)
        {
            return Result<Name>.Failure(NameErrors.LessThanMinimumCharacters);
        }

        return Result<Name>.Success(new Name(name));
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
