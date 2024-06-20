
using Application.Abstractions.CQRS;
using Application.Common;

using Domain.Common;

namespace Application.Admin.CommandHandlers;
internal class DeleteUserCommanHandler : ICommandHandler<IdCommand>
{
    public Task<Result> HandleAsync(IdCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
