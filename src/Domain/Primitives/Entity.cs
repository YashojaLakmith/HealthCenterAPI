using Domain.ValueObjects;

namespace Domain.Primitives;

public abstract class Entity : IEquatable<Entity>
{
    public Id Id { get; private init; }
    protected Entity()
    {
        Id = Id.CreateId().Value;
    }

    protected Entity(Id id)
    {
        Id = id;
    }

    public bool Equals(Entity? other)
    {
        return other is Entity e && Id == e.Id;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity? lhs, Entity? rhs)
    {
        return lhs is not null && lhs.Equals(rhs);
    }

    public static bool operator !=(Entity? lhs, Entity? rhs)
    {
        return !(lhs == rhs);
    }
}
