using Microsoft.EntityFrameworkCore;

namespace WebAPI.Schema;

[PrimaryKey(nameof(Medicine), nameof(Prescription))]
public class PrescribedMedicine
{
    public decimal Units { get; set; }
    public decimal UnitsPerDay { get; set; }

    public Medicine Medicine { get; set; }
    public Prescription Prescription { get; set; }
}
