using Application.Abstractions.CQRS;
using Application.Doctor.Commands;

using Domain.Common;

namespace Application.Doctor.CommandHandlers;
internal class ModifyContactInformationCommandHandler : ICommandHandler<ModifyContactInformationCommand>
{
    public Task<Result> HandleAsync(ModifyContactInformationCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
