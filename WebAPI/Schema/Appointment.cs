namespace WebAPI.Schema;

public class Appointment
{
    public string AppointmentId { get; private set; }
    public DateTime AppointmentCreatedOn { get; private set; }
    public AppointmentState AppointmentState { get; private set; }

    public PatientBase Patient { get; private set; }
    public Sessions Session { get; private set; }

    public Appointment() { }

    public static Appointment CreateAppointment(PatientBase Patient, Sessions session)
    {
        return new Appointment()
        {
            AppointmentId = Guid.NewGuid().ToString(),
            AppointmentCreatedOn = DateTime.Now,
            AppointmentState = AppointmentState.Waiting,
            Patient = Patient,
            Session = session
        };
    }

    public void MarkPatientArrived()
    {
        AppointmentState = AppointmentState.PatientArrived;
    }

    public void MarkPatientBeingServed()
    {
        AppointmentState = AppointmentState.PatientBeingServed;
    }

    public void MarkCompletedServing()
    {
        AppointmentState = AppointmentState.PatientWasServed;
    }
}
