using Domain.Common;
using Domain.Common.Errors;
using Domain.Primitives;

namespace Domain.ValueObjects;

public class Id : ValueObject
{
    public Guid Value { get; }

    private Id(Guid id)
    {
        Value = id;
    }

    public static Result<Id> CreateId(Guid id)
    {
        return Result<Id>.Success(new Id(id));
    }

    public static Id CreateId()
    {
        return new Id(Guid.NewGuid());
    }

    public static Result<Id> CreateId(string idString)
    {
        if(!Guid.TryParse(idString, out var guid))
        {
            return Result<Id>.Failure(IdErrors.InvalidId);
        }

        return new Id(guid);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
