using Application.Authentication.Abstractions.CQRS;
using Application.Authentication.Commands;

using Authentication.Abstractions.Services;
using Authentication.Repositories;
using Authentication.ValueObjects;

using Domain.Common;

namespace Application.Authentication.CommandHandlers;
internal class LogoutCommandHandler : ICommandHandler<LogoutCommand>
{
    private readonly ISessionTokenStore _tokenStore;

    public LogoutCommandHandler(ISessionTokenStore tokenStore)
    {
        _tokenStore = tokenStore;
    }

    public async Task<Result> HandleAsync(LogoutCommand command, CancellationToken cancellationToken = default)
    {
        var sessionTokenResult = SessionToken.CreateToken(command.Token);
        if (!sessionTokenResult.IsSuccess)
        {
            return sessionTokenResult;
        }

        return await _tokenStore.RevokeTokenAsync(sessionTokenResult.Value, cancellationToken);
    }
}
