namespace WebAPI.Schema;

public class Prescription
{
    public string PrescriptionId { get; set; }
    public string Remarks { get; set; }
    public DateTime IssuedOn { get; set; }

    public Doctor IssuedDoctor { get; set; }
    public PatientBase Patient { get; set; }
    public ICollection<PrescribedMedicine> PrescribedMedicine { get; set; }
    public Pharmacist? IssuedPharmacist { get; set; }
}
