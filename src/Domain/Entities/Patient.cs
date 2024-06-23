using Domain.Common;
using Domain.Common.Errors;
using Domain.Enum;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class Patient : Entity
{
    private List<Appointment> _appointments = [];

    public Name PatientName { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public EmailAddress EmailAddress { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }
    public Gender Gender { get; private set; }
    public (int years, int months) Age => CalculateAge();

    public IReadOnlyCollection<Appointment> Appointments => _appointments;

    private (int years, int months) CalculateAge()
    {
        var dob = DateOfBirth.Value;
        var now = DateTime.Now;

        var dobMonths = (dob.Year * 12) + dob.Month;
        var currentMonths = (now.Year * 12) + now.Month;
        var diff = currentMonths - dobMonths;

        return (diff / 12, diff % 12);
    }

    public static Result<Patient> CreatePatient(Name name, PhoneNumber phoneNumber, EmailAddress emailAddress, DateOfBirth dateOfBirth, Gender gender)
    {
        return new Patient(Id.CreateId(), [], name, phoneNumber, emailAddress, dateOfBirth, gender);
    }

    private Patient(Id id,
        IEnumerable<Appointment> appointments,
        Name patientName,
        PhoneNumber phoneNumber,
        EmailAddress emailAddress,
        DateOfBirth dateOfBirth,
        Gender gender) : base(id)
    {
        _appointments = [..appointments];
        PatientName = patientName;
        PhoneNumber = phoneNumber;
        EmailAddress = emailAddress;
        DateOfBirth = dateOfBirth;
        Gender = gender;
    }

    public Result AddAppointment(Session session)
    {
        if(session.SessionSpan.SessionStartValue < DateTime.UtcNow)
        {
            return Result.Failure(AppointmentErrors.SessionHasEnded);
        }

        var hasExistingAppointments = _appointments.Any(a => a.Session == session);

        if (hasExistingAppointments)
        {
            return Result.Failure(AppointmentErrors.EnrollingForSameSession);
        }

        var newAppointment = Appointment.Create(session, this);
        _appointments.Add(newAppointment);
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

    public Result RemoveAppointment(Id appointmentId)
    {
        var appointment = _appointments.FirstOrDefault(a => a.Id == appointmentId);
        if(appointment is null)
        {
            return Result.Failure(AppointmentErrors.AppointmentNotFound);
        }

        _appointments.Remove(appointment);
        return Result.Success();
    }
    
    private Patient(){}
}
