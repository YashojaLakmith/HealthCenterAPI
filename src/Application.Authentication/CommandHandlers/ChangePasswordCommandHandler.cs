using Application.Authentication.Abstractions.CQRS;
using Application.Authentication.Commands;

using Authentication.Repositories;
using Authentication.ValueObjects;

using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Authentication.CommandHandlers;
internal class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
{
    private readonly IAuthServiceRepository _authRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangePasswordCommandHandler(IAuthServiceRepository authRepository, IUnitOfWork unitOfWork)
    {
        _authRepository = authRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(ChangePasswordCommand command, CancellationToken cancellationToken = default)
    {
        var currentPwResult = Password.CreatePassword(command.CurrentPassword);
        var newPwResult = Password.CreatePassword(command.NewPassword);
        var idResult = Id.CreateId(command.UserId);

        // If current or new password invalid...

        var credentialResult = await _authRepository.GetCredentialObjectByIdAsync(idResult.Value, cancellationToken);

        // If not exists

        var authenticateResult = credentialResult.Value.AuthenticateUsingPassword(currentPwResult.Value);
        if (!authenticateResult.IsSuccess)
        {
            return authenticateResult;
        }

        var changeResult = credentialResult.Value.ChangePassword(newPwResult.Value);
        if (changeResult.IsSuccess)
        {
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        return changeResult;
    }
}
