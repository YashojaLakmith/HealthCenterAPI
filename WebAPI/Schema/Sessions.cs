using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class Sessions
{
    [Key]
    public string SessionId { get; set; }
    public DateTime SessionStart { get; set; }
    public decimal PricePerVisit { get; set; }
    public int SessionDurationMinutes { get; set; }
    public DateTime SessionCreatedOn { get; set; }

    public Rooms Room { get; set; }
    public Doctor Doctor { get; set; }
    public ICollection<Appointment> Appointments { get; set; }

    public override bool Equals(object? obj)
    {
        if(obj is Sessions s)
        {
            return GetHashCode() == s.GetHashCode() && SessionId.Equals(s.SessionId);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return SessionId.GetHashCode();
    }
}
