namespace WebAPI.Schema;

public class Doctor : EmployeeBase
{
    public string Description { get; private set; }
    public string RegistrationNo { get; private set; }

    public IReadOnlyCollection<Sessions> Sessions { get; private set; }
    public IReadOnlyCollection<DiagnosticRequest> DiagnosticRequests { get; private set; }
    public IReadOnlyCollection<Prescription> Prescriptions { get; private set; }

    public Doctor() { }

    public static Doctor CreateDoctor(string name, string description, string email, string phoneNumber, string registrationNumber, Genders gender, string nic)
    {
        return new Doctor()
        {
            EmployeeId = $@"DOC-{Guid.NewGuid()}",
            NIC = nic,
            EmployeeName = name,
            EmailAddress = email,
            Description = description,
            EmployeeCreatedOn = DateTime.Now,
            Gender = gender,
            PhoneNumber = phoneNumber,
            RegistrationNo = registrationNumber,
            Sessions = [],
            DiagnosticRequests = [],
            Prescriptions = [],
        };
    }
}
