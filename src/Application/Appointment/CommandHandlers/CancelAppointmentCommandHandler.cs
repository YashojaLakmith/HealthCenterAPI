using Application.Abstractions.CQRS;
using Application.Common;

using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Appointment.CommandHandlers;
internal class CancelAppointmentCommandHandler : ICommandHandler<IdCommandQuery>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CancelAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
    {
        _appointmentRepository = appointmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(IdCommandQuery command, CancellationToken cancellationToken = default)
    {
        var idResult = Id.CreateId(command.Id);
        var appointmentResult = await _appointmentRepository.GetByIdAsync(idResult.Value, cancellationToken);

        if (!appointmentResult.IsSuccess)
        {
            await _appointmentRepository.DeleteAsync(appointmentResult.Value, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        return Result.Failure(new Exception());
    }
}
