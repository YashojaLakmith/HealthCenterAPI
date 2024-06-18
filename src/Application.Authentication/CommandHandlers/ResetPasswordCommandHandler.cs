using Application.Authentication.Abstractions.CQRS;
using Application.Authentication.Abstractions.TokenManagement;
using Application.Authentication.Commands;

using Authentication.Repositories;
using Authentication.ValueObjects;

using Domain.Common;

namespace Application.Authentication.CommandHandlers;
internal class ResetPasswordCommandHandler : ICommandHandler<ResetPasswordCommand>
{
    private readonly IAuthServiceRepository _authRepository;
    private readonly IResetTokenManagement _resetTokenManager;

    public ResetPasswordCommandHandler(IAuthServiceRepository authRepository, IResetTokenManagement resetTokenManager)
    {
        _authRepository = authRepository;
        _resetTokenManager = resetTokenManager;
    }

    public async Task<Result> HandleAsync(ResetPasswordCommand command, CancellationToken cancellationToken = default)
    {
        var resetTokenResult = ResetToken.CreateToken(command.ResetToken);
        var claimsResult = await _resetTokenManager.VerifyResetTokenAsync(resetTokenResult.Value, cancellationToken);
        if (!claimsResult.IsSuccess)
        {
            return claimsResult;
        }


        throw new NotImplementedException();
    }
}
