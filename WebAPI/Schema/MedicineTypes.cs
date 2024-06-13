using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class MedicineTypes
{
    [Key]
    public string MedicineType { get; set; }

    public ICollection<Medicine> Medicines { get; set; }
}
