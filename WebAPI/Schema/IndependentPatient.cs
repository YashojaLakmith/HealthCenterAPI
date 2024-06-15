namespace WebAPI.Schema;

public class IndependentPatient : PatientBase
{
    public string NIC { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }

    public ICollection<DependentPatient> DependentPatients { get; set; }
    public ICollection<Query> Queries { get; set; }

    public IndependentPatient() { }

    public static IndependentPatient CreateIndependentPatient(string name, string nic, string email, string phoneNumber, DateTime dateofBirth, Genders gender)
    {
        return new IndependentPatient()
        {
            PatientId = Guid.NewGuid().ToString(),
            NIC = nic,
            EmailAddress = email,
            BirthDate = dateofBirth,
            DependentPatients = [],
            Appointments = [],
            Bills = [],
            DiagnosticRequests = [],
            DoctorNotes = string.Empty,
            Gender = gender,
            Invoices = [],
            PatientCreatedOn = DateTime.Now,
            PatientName = name,
            PhoneNumber = phoneNumber,
            Prescriptions = [],
            Queries = []
        };
    }

    public void RemoveDependentPatient(DependentPatient dependentPatient)
    {
        ICollection<DependentPatient> dependents = [];

        foreach(var p in DependentPatients)
        {
            if (!p.PatientId.Equals(dependentPatient.PatientId))
            {
                dependents.Add(p);
            }
        }

        DependentPatients = dependents;
    }
}
