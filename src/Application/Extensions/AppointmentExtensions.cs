using Application.Appointment.Views;

namespace Application.Extensions;
internal static class AppointmentExtensions
{
    public static AppointmentDetailView AsDetailView(this Domain.Entities.Appointment appointment)
    {
        return new AppointmentDetailView(
            appointment.Id.Value,
            appointment.Patient.Id.Value,
            appointment.Patient.PatientName.Value,
            appointment.Session.Doctor.Id.Value,
            appointment.Session.Doctor.DoctorName.Value,
            appointment.Session.Id.Value,
            appointment.Status
            );
    }
}
