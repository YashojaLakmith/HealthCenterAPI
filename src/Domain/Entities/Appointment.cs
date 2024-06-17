using Domain.Common;
using Domain.Enum;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class Appointment : Entity
{
    public AppointmentStatus Status { get; private set; }
    public DateTime AppointmentCreatedOn { get; private set; }
    public Session Session { get; private set; }
    public Patient Patient { get; private set; }

    private Appointment() : base() { }

    private Appointment(Id id, AppointmentStatus status, Session session, Patient patient) : base(id)
    {
        Status = status;
        Session = session;
        Patient = patient;
        AppointmentCreatedOn = DateTime.UtcNow;
    }

    public static Result<Appointment> Create(Session session, Patient patient)
    {
        if (patient.Appointments.Any(appointment => appointment.Session == session))
        {
            return Result<Appointment>.Failure(new Exception());
        }

        var idResult = Id.CreateId();
        var appointment = new Appointment(idResult.Value, AppointmentStatus.Pending, session, patient);
        return appointment;
    }

    public void PatientArrived()
    {
        Status = AppointmentStatus.PatientArrived;
    }

    public void PatientServed()
    {
        Status = AppointmentStatus.PatientWasServed;
    }
}
