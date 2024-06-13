namespace WebAPI.Schema;

public class Doctor : ServerSideUser
{
    public string Description { get; set; }
    public string RegistrationNo { get; set; }

    public ICollection<Sessions> Sessions { get; set; }
    public ICollection<DiagnosticRequest> DiagnosticRequests { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
}
