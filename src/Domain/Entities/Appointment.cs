using Domain.Common;
using Domain.Common.Errors;
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

    private Appointment(Id id, AppointmentStatus status, DateTime appointmentCreatedOn, Session session, Patient patient) : base(id)
    {
        Status = status;
        Session = session;
        Patient = patient;
        AppointmentCreatedOn = appointmentCreatedOn;
    }

    public static Appointment Create(Session session, Patient patient)
    {
        return new Appointment(Id.CreateId(), AppointmentStatus.Pending, DateTime.UtcNow, session, patient);
    }

    public Result PatientArrived()
    {
        if(Status != AppointmentStatus.Pending)
        {
            return Result.Failure(AppointmentErrors.MarkingNonPendingAppointmentAsPatientArrived);
        }

        Status = AppointmentStatus.PatientArrived;
        return Result.Success();
    }

    public Result PatientServed()
    {
        if(Status != AppointmentStatus.PatientArrived)
        {
            return Result.Failure(AppointmentErrors.MarkingNonArrivedPatientAsServed);
        }

        Status = AppointmentStatus.PatientWasServed;
        return Result.Success();
    }
    
    private Appointment(){}
}
