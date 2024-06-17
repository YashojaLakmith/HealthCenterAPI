using Application.Abstractions.CQRS;
using Application.Session.Commands;

using Domain.Common;

namespace Application.Session.CommandHandlers;
internal class CreateSessionCommandHandler : ICommandHandler<CreateSessionCommand>
{
    public Task<Result> HandleAsync(CreateSessionCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
