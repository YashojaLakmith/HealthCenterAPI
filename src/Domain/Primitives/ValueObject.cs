namespace Domain.Primitives;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public bool Equals(ValueObject? other)
    {
        return other is not null && AreValuesEqual(other);
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObject v && AreValuesEqual(v);
    }

    private bool AreValuesEqual(ValueObject other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Aggregate(default(int), HashCode.Combine);
    }

    public abstract IEnumerable<object> GetAtomicValues();

    public static bool operator ==(ValueObject? lhs, ValueObject? rhs)
    {
        return lhs is not null && lhs.Equals(rhs);
    }

    public static bool operator !=(ValueObject? lhs, ValueObject? rhs)
    {
        return !(lhs == rhs);
    }
}
