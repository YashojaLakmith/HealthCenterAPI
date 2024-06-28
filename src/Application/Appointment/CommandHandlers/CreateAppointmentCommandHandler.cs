using Application.Abstractions.CQRS;
using Application.Appointment.Commands;

using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Appointment.CommandHandlers;
internal class CreateAppointmentCommandHandler : ICommandHandler<NewAppointmentCommand>
{
    private readonly IPatientRepository _patientRepository;
    private readonly ISessionRepository _sessionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAppointmentCommandHandler(IPatientRepository patientRepository, ISessionRepository sessionRepository, IUnitOfWork unitOfWork)
    {
        _patientRepository = patientRepository;
        _sessionRepository = sessionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(NewAppointmentCommand command, CancellationToken cancellationToken = default)
    {
        var patientId = Id.CreateId(command.PatientId);
        var sessionId = Id.CreateId(command.SessionId);

        var patientResult = await _patientRepository.GetByIdAsync(patientId, cancellationToken);
        if (patientResult.IsFailure)
        {
            return patientResult;
        }

        var sessionResult = await _sessionRepository.GetByIdAsync(sessionId, cancellationToken);
        if (sessionResult.IsFailure)
        {
            return sessionResult;
        }

        var result = patientResult.Value.AddAppointment(sessionResult.Value);
        if (result.IsFailure)
        {
            return result;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
