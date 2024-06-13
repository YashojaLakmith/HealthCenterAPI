using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class Appointment
{
    [Key]
    public string AppointmentId { get; set; }
    public DateTime AppointmentCreatedOn { get; set; }
    public AppointmentState AppointmentState { get; set; }

    public PatientBase Patient { get; set; }
    public Sessions Session { get; set; }
}
