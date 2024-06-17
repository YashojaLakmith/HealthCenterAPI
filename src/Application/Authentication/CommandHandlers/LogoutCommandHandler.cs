using Application.Abstractions.CQRS;
using Application.Authentication.Commands;

using Domain.Common;

namespace Application.Authentication.CommandHandlers;
internal class LogoutCommandHandler : ICommandHandler<LogoutCommand>
{
    public Task<Result> HandleAsync(LogoutCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
