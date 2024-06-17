using Application.Authentication.Abstractions.CQRS;
using Application.Authentication.Commands;

using Domain.Common;

namespace Application.Authentication.CommandHandlers;
internal class ResetPasswordCommandHandler : ICommandHandler<ResetPasswordCommand>
{
    public Task<Result> HandleAsync(ResetPasswordCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
