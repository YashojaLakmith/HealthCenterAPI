using Application.Abstractions.CQRS;
using Application.Common;

using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

using Microsoft.Extensions.Logging;

namespace Application.Appointment.CommandHandlers;
internal class CancelAppointmentCommandHandler : ICommandHandler<IdCommand>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CancelAppointmentCommandHandler(
        IAppointmentRepository appointmentRepository,
        IUnitOfWork unitOfWork)
    {
        _appointmentRepository = appointmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(IdCommand command, CancellationToken cancellationToken = default)
    {
        var idResult = Id.CreateId(command.Id);
        var appointmentResult = await _appointmentRepository.GetByIdAsync(idResult.Value, cancellationToken);

        if (appointmentResult.IsFailure)
        {
            return appointmentResult;
        }

        await _appointmentRepository.DeleteAsync(appointmentResult.Value, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
