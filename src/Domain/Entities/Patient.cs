using Domain.Common;
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

    public static Result<Patient> CreatePatient(Name name, PhoneNumber phoneNumber, EmailAddress emailAddress, DateOfBirth dateOfBirth, Gender gender)
    {
        return new Patient(Id.CreateId().Value, name, phoneNumber, emailAddress, dateOfBirth, gender);
    }

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

    public Result AddAppointment(Session session)
    {
        if(_appointments.Any(appointment => appointment.Session == session))
        {
            // failed
        }

        var newAppointmentResult = Appointment.Create(session, this);
        _appointments.Add(newAppointmentResult.Value);

        return Result.Success();
    }

    public Result ChangePhoneNumber(PhoneNumber phoneNumber)
    {
        PhoneNumber = phoneNumber;
        return Result.Success();
    }

    public Result ChangeEmail(EmailAddress emailAddress)
    {
        EmailAddress = emailAddress;
        return Result.Success();
    }

    public Result RemoveAppointment(Appointment appointment)
    {
        throw new NotImplementedException();
    }
}
