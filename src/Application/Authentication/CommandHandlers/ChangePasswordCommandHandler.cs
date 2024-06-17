using Application.Abstractions.CQRS;
using Application.Authentication.Commands;

using Domain.Common;

namespace Application.Authentication.CommandHandlers;
internal class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
{
    public Task<Result> HandleAsync(ChangePasswordCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
