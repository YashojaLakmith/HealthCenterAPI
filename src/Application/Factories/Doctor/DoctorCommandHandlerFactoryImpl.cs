using Application.Abstractions.CQRS;
using Application.Abstractions.Factories.Doctor;
using Application.Common;
using Application.Doctor.CommandHandlers;
using Application.Doctor.Commands;
using Domain.Abstractions.DomainServices;
using Domain.Repositories;

namespace Application.Factories.Doctor;

internal sealed class DoctorCommandHandlerFactoryImpl : IDoctorCommandHandlerFactory
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICreateUserService _createUserService;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IEmailChangeService _emailChangeService;
    private readonly IPhoneNumberChangeService _phoneNumberChangeService;

    private ICommandHandler<CreateDoctorCommand>? _createHandler;
    private ICommandHandler<IdCommand>? _deleteHandler;
    private ICommandHandler<ModifyContactInformationCommand>? _modifyContactsHandler;
    private ICommandHandler<ModifyDescriptionCommand>? _modifyDescriptionHandler;

    public DoctorCommandHandlerFactoryImpl(
        IUnitOfWork unitOfWork,
        ICreateUserService createUserService,
        IDoctorRepository doctorRepository,
        IPhoneNumberChangeService phoneNumberChangeService,
        IEmailChangeService emailChangeService)
    {
        _unitOfWork = unitOfWork;
        _createUserService = createUserService;
        _doctorRepository = doctorRepository;
        _phoneNumberChangeService = phoneNumberChangeService;
        _emailChangeService = emailChangeService;
    }

    public ICommandHandler<CreateDoctorCommand> CreateDoctorCommandHandler
        => _createHandler ??= new CreateDoctorCommandHandler(_createUserService, _unitOfWork);

    public ICommandHandler<IdCommand> DeleteDoctorCommandHandler
        => _deleteHandler ??= new DeleteDoctorCommandHandler(_doctorRepository, _unitOfWork);

    public ICommandHandler<ModifyContactInformationCommand> ModifyContactInformationCommandHandler
        => _modifyContactsHandler ??= new ModifyContactInformationCommandHandler(
            _unitOfWork,
            _doctorRepository,
            _emailChangeService,
            _phoneNumberChangeService);

    public ICommandHandler<ModifyDescriptionCommand> ModifyDescriptionCommandHandler
        => _modifyDescriptionHandler ??= new ModifyDescriptionCommandHandler(_unitOfWork, _doctorRepository);
}