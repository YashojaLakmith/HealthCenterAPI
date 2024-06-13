namespace WebAPI.Schema;

public class DependentPatient : PatientBase
{
    public IndividualPatient IndividualPatient { get; set; }
}
