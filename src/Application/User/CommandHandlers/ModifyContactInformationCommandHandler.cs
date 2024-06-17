using Application.Abstractions.CQRS;
using Application.User.Commands;

using Domain.Common;

namespace Application.User.CommandHandlers;
internal class ModifyContactInformationCommandHandler : ICommandHandler<ModifyContactInformationCommand>
{
    public Task<Result> HandleAsync(ModifyContactInformationCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
