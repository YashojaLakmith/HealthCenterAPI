using Application.Abstractions.CQRS;
using Application.Appointment.Commands;

namespace Application.Factories;
public interface IAppointmentCommandHandlerFactory
{
    ICommandHandler<NewAppointmentCommand> CreateNewAppointmentCommandHandler();
}
