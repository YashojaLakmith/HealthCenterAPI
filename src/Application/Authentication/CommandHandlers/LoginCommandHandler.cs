using Application.Abstractions.CQRS;
using Application.Authentication.Commands;

using Domain.Common;

namespace Application.Authentication.CommandHandlers;
internal class LoginCommandHandler : ICommandHandler<string, LoginCommand>
{
    public Task<Result> HandleAsync(LoginCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
