using Application.Abstractions.CQRS;
using Application.Abstractions.Factories.Patient;
using Application.Common;
using Application.Patient.CommandHandlers;
using Application.Patient.Commands;
using Domain.Abstractions.DomainServices;
using Domain.Repositories;

namespace Application.Factories.Patient;

internal sealed class PatientCommandHandlerFactoryImpl : IPatientCommandHandlerFactory
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPatientRepository _patientRepository;
    private readonly ICreateUserService _createUserService;
    private readonly IEmailChangeService _emailChangeService;
    private readonly IPhoneNumberChangeService _phoneNumberChangeService;

    private ICommandHandler<CreatePatientCommand>? _createHandler;
    private ICommandHandler<IdCommand>? _deleteHandler;
    private ICommandHandler<ModifyContactInformationCommand>? _modifyHandler;

    public PatientCommandHandlerFactoryImpl(
        IUnitOfWork unitOfWork,
        IPatientRepository patientRepository,
        ICreateUserService createUserService,
        IEmailChangeService emailChangeService,
        IPhoneNumberChangeService phoneNumberChangeService)
    {
        _unitOfWork = unitOfWork;
        _patientRepository = patientRepository;
        _createUserService = createUserService;
        _emailChangeService = emailChangeService;
        _phoneNumberChangeService = phoneNumberChangeService;
    }

    public ICommandHandler<CreatePatientCommand> CreatePatientCommandHandler
        => _createHandler ??= new CreatePatientCommandHandler(_createUserService, _unitOfWork);

    public ICommandHandler<IdCommand> DeletePatientCommandHandler
        => _deleteHandler ??= new DeletePatientCommandHandler(_patientRepository, _unitOfWork);

    public ICommandHandler<ModifyContactInformationCommand> ModifyPatientContactInformationCommandHandler
        => _modifyHandler ??= new ModifyContactDetailsCommandHandler(
            _phoneNumberChangeService,
            _emailChangeService,
            _patientRepository,
            _unitOfWork);
}