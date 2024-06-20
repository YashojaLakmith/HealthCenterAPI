using Domain.Enum;

namespace Application.Appointment.Views;
public record AppointmentDetailView(Guid AppointmentId, Guid UserId, string UserName, Guid DoctorId, string DoctorName, Guid SessionId, AppointmentStatus AppointmentStatus);