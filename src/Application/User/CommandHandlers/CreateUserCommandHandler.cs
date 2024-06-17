using Application.Abstractions.CQRS;
using Application.User.Commands;

using Domain.Common;

namespace Application.User.CommandHandlers;
internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    public Task<Result> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
