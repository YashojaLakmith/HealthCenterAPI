using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class PrescribedMedicine
{
    [Key]
    public string Id { get; set; }
    public decimal Units { get; set; }
    public decimal UnitsPerDay { get; set; }

    public Medicine Medicine { get; set; }
    public Prescription Prescription { get; set; }

    public override bool Equals(object? obj)
    {
        if(obj is PrescribedMedicine p)
        {
            return GetHashCode() == p.GetHashCode() && Id.Equals(p.Id);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
