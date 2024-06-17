using Application.Abstractions.CQRS;
using Application.Appointment.Commands;

namespace Application.Factories;
public class AppointmentCommandHandlerFactoryImpl : IAppointmentCommandHandlerFactory
{
    public ICommandHandler<NewAppointmentCommand> CreateNewAppointmentCommandHandler()
    {
        throw new NotImplementedException();
    }
}
