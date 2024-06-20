using Application.Authentication.Abstractions.CQRS;
using Application.Authentication.Commands;

using Authentication.Abstractions.Services;
using Authentication.ValueObjects;

using Domain.Common;
using Domain.ValueObjects;

namespace Application.Authentication.CommandHandlers;
internal sealed class PasswordResetTokenRequestCommanHandler : ICommandHandler<ResetToken, ResetTokenRequestCommand>
{
    private readonly IResetTokenRequetService _resetTokenRequestService;

    public PasswordResetTokenRequestCommanHandler(IResetTokenRequetService resetTokenRequestService)
    {
        _resetTokenRequestService = resetTokenRequestService;
    }

    public async Task<Result<ResetToken>> HandleAsync(ResetTokenRequestCommand command, CancellationToken cancellationToken = default)
    {
        var emailResult = EmailAddress.CreateEmailAddress(command.EmailAddress);
        if (emailResult.IsFailure)
        {
            return Result<ResetToken>.Failure(emailResult.Error);
        }

        return await _resetTokenRequestService.RequestResetTokenAsync(emailResult.Value, cancellationToken);
    }
}
