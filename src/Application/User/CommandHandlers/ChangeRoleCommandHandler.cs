using Application.Abstractions.CQRS;
using Application.User.Commands;

using Domain.Common;

namespace Application.User.CommandHandlers;
internal class ChangeRoleCommandHandler : ICommandHandler<ChangeRoleCommand>
{
    public Task<Result> HandleAsync(ChangeRoleCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
