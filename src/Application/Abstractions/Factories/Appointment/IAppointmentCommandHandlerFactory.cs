using Application.Abstractions.CQRS;
using Application.Appointment.Commands;
using Application.Common;

namespace Application.Abstractions.Factories.Appointment;
public interface IAppointmentCommandHandlerFactory
{
    public ICommandHandler<NewAppointmentCommand> CreateAppointmentCommandHandler { get; }
    public ICommandHandler<IdCommandQuery> CancelAppointmentCommandHandler { get; }
}
