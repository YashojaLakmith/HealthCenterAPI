using Application.Authentication.Abstractions.CQRS;
using Application.Authentication.Commands;

using Authentication.Abstractions.Services;
using Authentication.ValueObjects;

using Domain.Common;

namespace Application.Authentication.CommandHandlers;
internal class ResetPasswordCommandHandler : ICommandHandler<ResetPasswordCommand>
{
    private readonly ITokenBasedPasswordResetService _resetService;

    public ResetPasswordCommandHandler(ITokenBasedPasswordResetService resetService)
    {
        _resetService = resetService;
    }

    public async Task<Result> HandleAsync(ResetPasswordCommand command, CancellationToken cancellationToken = default)
    {
        var tokenResult = ResetToken.CreateToken(command.ResetToken);
        if (tokenResult.IsFailure)
        {
            return tokenResult;
        }

        var pwResult = Password.CreatePassword(command.NewPassword);
        if (pwResult.IsFailure)
        {
            return pwResult;
        }

        return await _resetService.ChangePasswordAsync(tokenResult.Value, pwResult.Value, cancellationToken);
    }
}
