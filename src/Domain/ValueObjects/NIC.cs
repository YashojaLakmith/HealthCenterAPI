using Domain.Common;
using Domain.Common.Errors;
using Domain.Primitives;

namespace Domain.ValueObjects;

public sealed class NIC : ValueObject
{
    public const int NICLength1 = 12;
    public const int NICLength2 = 9;

    public string Value { get; }

    public static Result<NIC> Create(string nic)
    {
        if(string.IsNullOrWhiteSpace(nic) || nic == string.Empty)
        {
            return Result<NIC>.Failure(NICErrors.EmptyNIC);
        }

        if(nic.Length != NICLength1 || nic.Length != NICLength2)
        {
            return Result<NIC>.Failure(NICErrors.InvalidLength);
        }

        if(nic.Length == NICLength1 && !Validate12DigitNIC(nic))
        {
            return Result<NIC>.Failure(NICErrors.InvalidCharacterIn12DigitNIC);
        }

        if(nic.Length == NICLength2 && !Validate9DigitNIC(nic))
        {
            return Result<NIC>.Failure(NICErrors.InvalidCharacterIn9DigitNIC);
        }

        return Result<NIC>.Success(new NIC(nic));
    }

    private static bool Validate12DigitNIC(string nic)
    {
        return ulong.TryParse(nic, out _);
    }

    private static bool Validate9DigitNIC(ReadOnlySpan<char> nic)
    {
        var lastChar = nic[NICLength2 - 1];
        if(lastChar !='X' || lastChar != 'x' || lastChar != 'v' || lastChar != 'V')
        {
            return false;
        }

        var slice = nic[..(NICLength2 - 1)];

        return ulong.TryParse(slice, out _);
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
