using Application.Abstractions.CQRS;
using Application.Appointment.Commands;
using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Appointment.CommandHandlers;
internal class CreateAppointmentCommandHandler : ICommandHandler<NewAppointmentCommand>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly ISessionRepository _sessionRepository;

    public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IPatientRepository patientRepository, ISessionRepository sessionRepository)
    {
        _appointmentRepository = appointmentRepository;
        _patientRepository = patientRepository;
        _sessionRepository = sessionRepository;
    }

    public async Task<Result> HandleAsync(NewAppointmentCommand command, CancellationToken cancellationToken = default)
    {
        var patientIdResult = Id.CreateId(command.PatientId);
        var sessionIdResult = Id.CreateId(command.SessionId);

        var patientResult = await _patientRepository.GetByIdAsync(patientIdResult.Value, cancellationToken);
        if(!patientResult.IsSuccess)
        {
            // Failure
        }

        var sessionResult = await _sessionRepository.GetByIdAsync(sessionIdResult.Value, cancellationToken);
        if(!sessionResult.IsSuccess)
        {
            // Failure
        }

        var registeredResult = await _appointmentRepository.HasAlredyRegisteredAsync(patientIdResult.Value, sessionIdResult.Value, cancellationToken);
        if (registeredResult.IsSuccess && registeredResult.Value)
        {
            // Failure
        }

        var newAppointment = Domain.Entities.Appointment.Create(sessionResult.Value, patientResult.Value);
        var result = await _appointmentRepository.InsertNewAsync(newAppointment.Value, cancellationToken);

        if (result.IsSuccess)
        {
            return result;
        }

        return Result.Failure(new Exception());
    }
}
