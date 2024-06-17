
using Application.Abstractions.CQRS;
using Application.Common;

using Domain.Common;

namespace Application.User.CommandHandlers;
internal class DeleteUserCommanHandler : ICommandHandler<IdCommandQuery>
{
    public Task<Result> HandleAsync(IdCommandQuery command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
