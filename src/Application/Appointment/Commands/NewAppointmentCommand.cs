using Application.Abstractions.CQRS;

namespace Application.Appointment.Commands;
public sealed record NewAppointmentCommand(Guid PatientId, Guid SessionId) : ICommand;
