using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class UnitsOfMedicineMeasurement
{
    [Key]
    public string MeasurementUnit { get; set; }

    public ICollection<Medicine> Medicines { get; set; }

    public override int GetHashCode()
    {
        return MeasurementUnit.ToLower()
            .GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if(obj is UnitsOfMedicineMeasurement u)
        {
            return GetHashCode() == u.GetHashCode() && MeasurementUnit.Equals(u.MeasurementUnit, StringComparison.OrdinalIgnoreCase);
        }

        return false;
    }
}
