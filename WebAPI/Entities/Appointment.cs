namespace WebAPI.Entities;

public class Appointment
{
    public AppointmentState State { get; set; }

    public static Appointment Create()
    {
        return new Appointment();
    }

    public void MarkUserArrived()
    {

    }

    public void MarkUserBeingServed()
    {

    }

    public void MarkCompleted()
    {

    }

    public void MarkCancel()
    {

    }

    private Appointment() { }
}
