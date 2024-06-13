using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class Medicine
{
    [Key]
    public string MedicineId { get; set; }
    public string MedicineName { get; set; }
    public decimal PricePerUnit { get; set; }

    public MedicineTypes MedicineType { get; set; }
    public UnitsOfMedicineMeasurement UnitOfMeasurement { get; set; }
}
