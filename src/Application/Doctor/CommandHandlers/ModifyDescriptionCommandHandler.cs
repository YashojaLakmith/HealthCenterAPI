using Application.Abstractions.CQRS;
using Application.Doctor.Commands;

using Domain.Common;

namespace Application.Doctor.CommandHandlers;
internal class ModifyDescriptionCommandHandler : ICommandHandler<ModifyDescriptionCommand>
{
    public Task<Result> HandleAsync(ModifyDescriptionCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
