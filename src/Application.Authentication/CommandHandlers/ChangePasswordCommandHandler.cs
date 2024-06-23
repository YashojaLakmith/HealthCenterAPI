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
    private readonly ICredentialRepository _credentialRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangePasswordCommandHandler(ICredentialRepository credentialRepository, IUnitOfWork unitOfWork)
    {
        _credentialRepository = credentialRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(ChangePasswordCommand command, CancellationToken cancellationToken = default)
    {
        var currentPwResult = Password.CreatePassword(command.CurrentPassword);
        if (currentPwResult.IsFailure)
        {
            return currentPwResult;
        }

        var newPwResult = Password.CreatePassword(command.NewPassword);
        if (newPwResult.IsFailure)
        {
            return newPwResult;
        }

        var emailResult = EmailAddress.CreateEmailAddress(command.EmailAddress);
        if (emailResult.IsFailure)
        {
            return emailResult;
        }

        var credentialResult = await _credentialRepository.GetCredentialObjectByEmailAsync(emailResult.Value, cancellationToken);
        if (credentialResult.IsFailure)
        {
            return credentialResult;
        }

        var changeResult = credentialResult.Value.ChangePasswordAfterAuthenticating(currentPwResult.Value, newPwResult.Value);
        if(changeResult.IsFailure)
        {
            return changeResult;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
