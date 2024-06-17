using Application.Abstractions.CQRS;
using Application.Common;

using Domain.Common;

namespace Application.Patient.CommandHandlers;
internal class DeletePatientCommandHandler : ICommandHandler<IdCommandQuery>
{
    public Task<Result> HandleAsync(IdCommandQuery command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
