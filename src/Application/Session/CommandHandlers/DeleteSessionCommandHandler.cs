using Application.Abstractions.CQRS;
using Application.Common;

using Domain.Common;

namespace Application.Session.CommandHandlers;
internal class DeleteSessionCommandHandler : ICommandHandler<IdCommandQuery>
{
    public Task<Result> HandleAsync(IdCommandQuery command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
