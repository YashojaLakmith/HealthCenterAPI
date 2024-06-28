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

    public static Id CreateId(Guid id)
    {
        return new Id(id);
    }

    public static Id CreateId()
    {
        return new Id(Guid.NewGuid());
    }

    public static Result<Id> CreateId(string idString)
    {
        return !Guid.TryParse(idString, out var guid) 
            ? Result<Id>.Failure(IdErrors.InvalidId) 
            : new Id(guid);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
