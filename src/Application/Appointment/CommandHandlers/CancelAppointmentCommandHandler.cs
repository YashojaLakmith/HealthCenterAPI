using Application.Abstractions.CQRS;
using Application.Common;

using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Appointment.CommandHandlers;
internal class CancelAppointmentCommandHandler : ICommandHandler<IdCommandQuery>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public CancelAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Result> HandleAsync(IdCommandQuery command, CancellationToken cancellationToken = default)
    {
        var idResult = Id.CreateId(command.Id);
        var existResult = await _appointmentRepository.ExistsAsync(idResult.Value, cancellationToken);

        if (existResult.IsSuccess && existResult.Value)
        {
            await _appointmentRepository.DeleteAsync(idResult.Value, cancellationToken);
            return Result.Success();
        }

        return Result.Failure(new Exception());
    }
}
