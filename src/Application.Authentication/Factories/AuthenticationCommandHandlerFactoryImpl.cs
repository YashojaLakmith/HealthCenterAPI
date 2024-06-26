using Application.Authentication.Abstractions.CQRS;
using Application.Authentication.Abstractions.Factories;
using Application.Authentication.CommandHandlers;
using Application.Authentication.Commands;
using Authentication.Abstractions.Services;
using Authentication.Repositories;
using Authentication.ValueObjects;
using Domain.Repositories;

namespace Application.Authentication.Factories;

public class AuthenticationCommandHandlerFactoryImpl : IAuthenticationCommandHandlerFactory
{
    private readonly ICredentialRepository _credentialRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordAuthenticationService _authenticationService;
    private readonly ISessionTokenStore _sessionTokenStore;
    private readonly IResetTokenRequetService _tokenRequetService;
    private readonly ITokenBasedPasswordResetService _resetService;

    private ICommandHandler<ChangePasswordCommand>? _changePasswordHandler;
    private ICommandHandler<SessionToken, LoginCommand>? _loginHandler;
    private ICommandHandler<LogoutCommand>? _logoutHandler;
    private ICommandHandler<ResetToken, ResetTokenRequestCommand>? _resetRequestHandler;
    private ICommandHandler<ResetPasswordCommand>? _resetPasswordHandler;

    public AuthenticationCommandHandlerFactoryImpl(
        ICredentialRepository credentialRepository,
        IUnitOfWork unitOfWork,
        IPasswordAuthenticationService authenticationService,
        ISessionTokenStore sessionTokenStore,
        IResetTokenRequetService tokenRequetService,
        ITokenBasedPasswordResetService resetService)
    {
        _credentialRepository = credentialRepository;
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
        _sessionTokenStore = sessionTokenStore;
        _tokenRequetService = tokenRequetService;
        _resetService = resetService;
    }

    public ICommandHandler<ChangePasswordCommand> ChangePasswordCommandHandler
        => _changePasswordHandler ??= new ChangePasswordCommandHandler(_credentialRepository, _unitOfWork);

    public ICommandHandler<SessionToken, LoginCommand> LoginCommandHandler
        => _loginHandler ??= new LoginCommandHandler(_authenticationService);

    public ICommandHandler<LogoutCommand> LogoutCommandHandler
        => _logoutHandler ??= new LogoutCommandHandler(_sessionTokenStore);

    public ICommandHandler<ResetToken, ResetTokenRequestCommand> ResetTokenRequestCommandHandler
        => _resetRequestHandler ??= new PasswordResetTokenRequestCommanHandler(_tokenRequetService);

    public ICommandHandler<ResetPasswordCommand> ResetPasswordCommandHandler
        => _resetPasswordHandler ??= new ResetPasswordCommandHandler(_resetService);
}