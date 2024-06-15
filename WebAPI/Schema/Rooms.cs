using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class Rooms
{
    [Key]
    public string Room { get; set; }

    public ICollection<Sessions> Sessions { get; set; }

    public override int GetHashCode()
    {
        return Room.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if(obj is Rooms r)
        {
            return GetHashCode() == r.GetHashCode() && Room.Equals(r.Room);
        }

        return false;
    }
}
