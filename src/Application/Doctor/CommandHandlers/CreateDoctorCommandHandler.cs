using Application.Abstractions.CQRS;
using Application.Doctor.Commands;

using Domain.Common;

namespace Application.Doctor.CommandHandlers;
internal class CreateDoctorCommandHandler : ICommandHandler<CreateDoctorCommand>
{
    public Task<Result> HandleAsync(CreateDoctorCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
