using Application.Abstractions.CQRS;
using Application.Admin.Commands;

using Domain.Common;

namespace Application.Admin.CommandHandlers;
internal class ModifyContactInformationCommandHandler : ICommandHandler<ModifyContactInformationCommand>
{
    public Task<Result> HandleAsync(ModifyContactInformationCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
