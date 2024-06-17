using Domain.Common;
using Domain.Primitives;

namespace Domain.ValueObjects;

public sealed class NIC : ValueObject
{
    public const int NICLength1 = 12;
    public const int NICLength2 = 9;

    public string Value { get; }

    public static Result<NIC> Create(string nic)
    {
        if(nic.Length != NICLength1 || nic.Length != NICLength2)
        {
            return Result<NIC>.Failure(new ArgumentException());
        }

        return Result<NIC>.Success(new NIC(nic));
    }

    private NIC(string nic)
    {
        Value = nic;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
