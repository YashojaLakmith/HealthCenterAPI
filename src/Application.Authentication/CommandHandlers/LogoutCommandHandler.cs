using Application.Authentication.Abstractions.CQRS;
using Application.Authentication.Abstractions.SessionManagement;
using Application.Authentication.Commands;

using Authentication.Repositories;

using Domain.Common;

namespace Application.Authentication.CommandHandlers;
internal class LogoutCommandHandler : ICommandHandler<LogoutCommand>
{
    private readonly IAuthServiceRepository _authRepository;
    private readonly ISessionManagement _sessionManager;

    public LogoutCommandHandler(ISessionManagement sessionManager, IAuthServiceRepository authRepository)
    {
        _sessionManager = sessionManager;
        _authRepository = authRepository;
    }

    public async Task<Result> HandleAsync(LogoutCommand command, CancellationToken cancellationToken = default)
    {
        return await _sessionManager.RevokeSessionAsync(command.Token, cancellationToken);
    }
}
