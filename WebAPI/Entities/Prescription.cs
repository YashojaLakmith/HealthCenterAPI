using WebAPI.Schema;

namespace WebAPI.Entities;

public class Prescription
{
    public string PrescriptionId { get; private set; }
    public DateTime PrescriptionIssuedOn { get; private set; }

    public IEnumerable<PrescribedMedicine> PrescribedMedicines { get; private set; }
    public Doctor IssuedDoctor { get; private set; }
    public PatientBase IssuedPatient { get; private set; }
    public Pharmacist? MedicineIssuedBy { get; private set; }
}
