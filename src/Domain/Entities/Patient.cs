using Domain.Enum;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Patient : Entity
{
    private readonly List<Appointment> _appointments = [];

    public Name PatientName { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public EmailAddress EmailAddress { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }
    public (int years, int months) Age => CalculateAge();
    public Gender Gender { get; private set; }

    public IReadOnlyCollection<Appointment> Appointments => _appointments;

    private (int years, int months) CalculateAge()
    {
        var dob = DateOfBirth.Value;
        var now = DateTime.Now;

        var dobMonths = (dob.Year * 12) + dob.Month;
        var currentMonths = (now.Year * 12) + now.Month;
        var diff = currentMonths - dobMonths;
        
        return (diff / 12,  diff % 12);
    }

    private Patient() : base() { }

    private Patient(Id id, Name name, PhoneNumber phoneNumber, EmailAddress emailAddress, DateOfBirth dateOfBirth, Gender gender) : base(id)
    {
        PatientName = name;
        PhoneNumber = phoneNumber;
        EmailAddress = emailAddress;
        DateOfBirth = dateOfBirth;
        Gender = gender;
    }
}
