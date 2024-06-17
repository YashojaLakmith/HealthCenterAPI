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
        return new Appointment(Id.CreateId().Value, AppointmentStatus.Pending, session, patient);
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
