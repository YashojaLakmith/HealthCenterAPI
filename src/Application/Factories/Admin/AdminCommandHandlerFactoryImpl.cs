using Application.Abstractions.CQRS;
using Application.Abstractions.Events;
using Application.Abstractions.Factories.Admin;
using Application.Abstractions.Invoker;
using Application.Admin.CommandHandlers;
using Application.Admin.Commands;
using Application.Common;

using Domain.Abstractions.DomainServices;
using Domain.Repositories;

namespace Application.Factories.Admin;

internal sealed class AdminCommandHandlerFactoryImpl : IAdminCommandHandlerFactory
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAdminRepository _adminRepository;
    private readonly IChangeAdminRoleService _adminRoleService;
    private readonly IEmailChangeService _emailChangeService;
    private readonly IPhoneNumberChangeService _phoneNumberChangeService;
    private readonly IDeleteAdminService _deleteAdminService;
    private readonly ICreateUserService _createUserService;
    private readonly ICommandQueryInvoker _invoker;
    private readonly IAdminCreatedEventPublisher _eventPublisher;

    private ICommandHandler<ChangeRoleCommand>? _changeRoleHandler;
    private ICommandHandler<CreateAdminCommand>? _createHandler;
    private ICommandHandler<IdCommand>? _deleteHandler;
    private ICommandHandler<ModifyContactInformationCommand>? _modifyHandler;

    public AdminCommandHandlerFactoryImpl(
        IUnitOfWork unitOfWork,
        IAdminRepository adminRepository,
        IChangeAdminRoleService adminRoleService,
        IEmailChangeService emailChangeService,
        IPhoneNumberChangeService phoneNumberChangeService,
        ICreateUserService createUserService,
        ICommandQueryInvoker invoker, IAdminCreatedEventPublisher eventPublisher, IDeleteAdminService deleteAdminService)
    {
        _unitOfWork = unitOfWork;
        _adminRepository = adminRepository;
        _adminRoleService = adminRoleService;
        _emailChangeService = emailChangeService;
        _phoneNumberChangeService = phoneNumberChangeService;
        _createUserService = createUserService;
        _invoker = invoker;
        _eventPublisher = eventPublisher;
        _deleteAdminService = deleteAdminService;
    }

    public ICommandHandler<ChangeRoleCommand> ChangeRoleCommandHandler
        => _changeRoleHandler ??= new ChangeRoleCommandHandler(
            _unitOfWork,
            _adminRoleService,
            _adminRepository,
            _invoker);

    public ICommandHandler<CreateAdminCommand> CreateAdminCommandHandler
        => _createHandler ??= new CreateAdminCommandHandler(
            _eventPublisher,
            _createUserService,
            _invoker,
            _unitOfWork);

    public ICommandHandler<IdCommand> DeleteAdminCommandHandler
        => _deleteHandler ??= new DeleteAdminCommandHandler(
            _deleteAdminService,
            _invoker,
            _unitOfWork);

    public ICommandHandler<ModifyContactInformationCommand> ModifyContactInformationCommandHandler
        => _modifyHandler ??= new ModifyContactInformationCommandHandler(
            _emailChangeService,
            _phoneNumberChangeService,
            _invoker,
            _unitOfWork,
            _adminRepository);
}