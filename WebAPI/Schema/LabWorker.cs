namespace WebAPI.Schema;

public class LabWorker : BillIssuer
{
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }

    public ICollection<MedicalReport> IssuedMedicalReports { get; set; }
}
