using Application.Abstractions.CQRS;
using Application.Common;

using Domain.Common;

namespace Application.Doctor.CommandHandlers;
internal class DeleteDoctorCommandHandler : ICommandHandler<IdCommandQuery>
{
    public Task<Result> HandleAsync(IdCommandQuery command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
