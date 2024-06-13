namespace WebAPI.Schema;

public class IndividualPatient : PatientBase
{
    public string NIC { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }

    public ICollection<DependentPatient> DependentPatients { get; set; }
}
