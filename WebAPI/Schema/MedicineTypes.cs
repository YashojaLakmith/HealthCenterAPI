using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class MedicineTypes
{
    [Key]
    public string MedicineType { get; set; }

    public ICollection<Medicine> Medicines { get; set; }

    public override bool Equals(object? obj)
    {
        if(obj is MedicineTypes m)
        {
            return GetHashCode() == m.GetHashCode() && MedicineType.Equals(m.MedicineType, StringComparison.OrdinalIgnoreCase);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return MedicineType.GetHashCode();
    }
}
