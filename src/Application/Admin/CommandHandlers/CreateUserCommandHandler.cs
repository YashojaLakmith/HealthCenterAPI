using Application.Abstractions.CQRS;
using Application.Admin.Commands;

using Domain.Common;

namespace Application.Admin.CommandHandlers;
internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    public Task<Result> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
