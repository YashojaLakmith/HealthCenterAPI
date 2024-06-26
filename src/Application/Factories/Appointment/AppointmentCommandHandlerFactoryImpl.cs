using Application.Abstractions.CQRS;
using Application.Abstractions.Factories.Appointment;
using Application.Appointment.CommandHandlers;
using Application.Appointment.Commands;
using Application.Common;
using Domain.Repositories;

using Microsoft.Extensions.Logging;

namespace Application.Factories.Appointment;
internal sealed class AppointmentCommandHandlerFactoryImpl : IAppointmentCommandHandlerFactory
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly ISessionRepository _sessionRepository;
    private readonly IUnitOfWork _unitOfWork;

    private ICommandHandler<NewAppointmentCommand>? _createHandler;
    private ICommandHandler<IdCommand>? _cancelHandler;

    public AppointmentCommandHandlerFactoryImpl(
        IUnitOfWork unitOfWork,
        ISessionRepository sessionRepository,
        IAppointmentRepository appointmentRepository,
        IPatientRepository patientRepository)
    {
        _unitOfWork = unitOfWork;
        _sessionRepository = sessionRepository;
        _appointmentRepository = appointmentRepository;
        _patientRepository = patientRepository;
    }

    public ICommandHandler<NewAppointmentCommand> CreateAppointmentCommandHandler
        => _createHandler ??= new CreateAppointmentCommandHandler(_patientRepository, _sessionRepository, _unitOfWork);
    public ICommandHandler<IdCommand> CancelAppointmentCommandHandler
        => _cancelHandler ??= new CancelAppointmentCommandHandler(_appointmentRepository, _unitOfWork);
}
