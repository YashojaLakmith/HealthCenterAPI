using Application.Abstractions.CQRS;
using Application.Patient.Commands;

using Domain.Common;

namespace Application.Patient.CommandHandlers;
internal class CreatePatientCommandHandler : ICommandHandler<CreatePatientCommand>
{
    public Task<Result> HandleAsync(CreatePatientCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
