using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public abstract class PatientBase
{
    [Key]
    public string PatientId { get; set; }
    public string PatientName { get; set; }
    public DateTime PatientCreatedOn { get; set; }
    public DateTime BirthDate { get; set; }
    public string DoctorNotes { get; set; }

    public Genders Gender { get; set; }
    public ICollection<PaymentInvoice> Invoices { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Bill> Bills { get; set; }
    public ICollection<DiagnosticRequest> DiagnosticRequests { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }

    public override int GetHashCode()
    {
        return PatientId.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if(obj is PatientBase p)
        {
            return GetHashCode() == p.GetHashCode() && p.PatientId.Equals(PatientId);
        }

        return false;
    }
}
