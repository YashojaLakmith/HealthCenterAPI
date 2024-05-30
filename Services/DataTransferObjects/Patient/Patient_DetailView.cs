namespace Services.DataTransferObjects.Patient;

public record Patient_DetailView
{
    public string PatientId { get; init; }
    public string NIC { get; init; }
    public uint Gender { get; init; }
    public Age Age { get; init; }
    public string PhoneNumber { get; init; }
    public string EmailAddress { get; init; }

    public Patient_DetailView(string patientId, string nic, uint gender, DateTime birthDate, string phoneNumber, string emailAddress)
    {
        PatientId = patientId;
        NIC = nic;
        Gender = gender;
        PhoneNumber = phoneNumber;
        EmailAddress = emailAddress;
        
        (var y, var m) = GetAgeInYearsAndMonths(birthDate);
        Age = new(y, m);
    }

    private static (uint years, uint months) GetAgeInYearsAndMonths(DateTime birthDate)
    {
        var now = DateTime.Now;
        var currentM = now.Year * 12 + now.Month;
        var birthM = birthDate.Year * 12 + birthDate.Month;
        var ageM = (uint) currentM - (uint) birthM;

        return (ageM / 12, ageM % 12);
    }
}
