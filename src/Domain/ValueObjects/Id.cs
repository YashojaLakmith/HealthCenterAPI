using Domain.Common;
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

    public static Result<Id> CreateId()
    {
        return Result<Id>.Success(new Id(Guid.NewGuid()));
    }

    public static Result<Id> CreateId(string idString)
    {
        try
        {
            var guid = new Guid(idString);
            return Result<Id>.Success(new Id(guid));
        }
        catch (FormatException ex)
        {
            return Result<Id>.Failure(ex);
        }
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
