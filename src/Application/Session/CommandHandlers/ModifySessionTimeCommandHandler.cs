using Application.Abstractions.CQRS;
using Application.Session.Commands;

using Domain.Common;

namespace Application.Session.CommandHandlers;
internal class ModifySessionTimeCommandHandler : ICommandHandler<ModifySessionTimeCommand>
{
    public Task<Result> HandleAsync(ModifySessionTimeCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
