namespace WebAPI.Schema;

public abstract class PatientBase : UserBase
{
    public Genders Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string DoctorNotes { get; set; }

    public ICollection<PaymentInvoice> Invoices { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Bill> Bills { get; set; }
    public ICollection<DiagnosticRequest> DiagnosticRequests { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
}
