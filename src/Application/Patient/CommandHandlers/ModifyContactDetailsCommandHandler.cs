using Application.Abstractions.CQRS;
using Application.Patient.Commands;

using Domain.Common;

namespace Application.Patient.CommandHandlers;
internal class ModifyContactDetailsCommandHandler : ICommandHandler<ModifyContactInformationCommand>
{
    public Task<Result> HandleAsync(ModifyContactInformationCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
