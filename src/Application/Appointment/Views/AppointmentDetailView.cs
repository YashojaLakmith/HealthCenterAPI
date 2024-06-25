using Domain.Enum;

namespace Application.Appointment.Views;
public record AppointmentDetailView(Guid AppointmentId, Guid UserId, string UserName, Guid SessionId, AppointmentStatus AppointmentStatus);