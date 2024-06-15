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
    public ICollection<PrescribedMedicine> Prescribings { get; set; }

    public override int GetHashCode()
    {
        return MedicineId.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if(obj is  Medicine m)
        {
            return GetHashCode() == m.GetHashCode() && MedicineId.Equals(m.MedicineId);
        }

        return false;
    }
}
