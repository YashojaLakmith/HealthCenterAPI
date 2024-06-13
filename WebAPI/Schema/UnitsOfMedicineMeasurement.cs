using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class UnitsOfMedicineMeasurement
{
    [Key]
    public string MeasurementUnit { get; set; }

    public ICollection<Medicine> Medicines { get; set; }
}
