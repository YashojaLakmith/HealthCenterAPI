using Application.Abstractions.CQRS;
using Application.Abstractions.Invoker;
using Application.Admin.Commands;
using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Admin.CommandHandlers;
internal class ModifyContactInformationCommandHandler : ICommandHandler<ModifyContactInformationCommand>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IEmailChangeService _emailChangeService;
    private readonly IPhoneNumberChangeService _phoneNumberChangeService;
    private readonly ICommandQueryInvoker _invoker;
    private readonly IUnitOfWork _unitOfWork;

    public ModifyContactInformationCommandHandler(IEmailChangeService emailChangeService, IPhoneNumberChangeService phoneNumberChangeService, ICommandQueryInvoker invoker, IUnitOfWork unitOfWork, IAdminRepository adminRepository)
    {
        _emailChangeService = emailChangeService;
        _phoneNumberChangeService = phoneNumberChangeService;
        _invoker = invoker;
        _unitOfWork = unitOfWork;
        _adminRepository = adminRepository;
    }

    public async Task<Result> HandleAsync(ModifyContactInformationCommand command, CancellationToken cancellationToken = default)
    {
        var id = Id.CreateId(command.UserId);

        var emailResult = command.NewEmail is null ? null : EmailAddress.CreateEmailAddress(command.NewEmail);
        if (emailResult is not null && emailResult.IsFailure)
        {
            return emailResult;
        }
        
        var phoneNumberResult = command.NewPhoneNumber is null ? null : PhoneNumber.CreatePhoneNumber(command.NewPhoneNumber);
        if (phoneNumberResult is not null && phoneNumberResult.IsFailure)
        {
            return phoneNumberResult;
        }

        if (emailResult is null && phoneNumberResult is null)
        {
            return Result.Success();
        }

        var invokerResult = await _invoker.GetInvokingUserAsync(cancellationToken);
        if (invokerResult.IsFailure)
        {
            return invokerResult;
        }

        var adminResult = await _adminRepository.GetByIdAsync(id, cancellationToken);
        if (adminResult.IsFailure)
        {
            return adminResult;
        }

        if (emailResult is not null)
        {
            var changeResult = await _emailChangeService.ChangeAdminEmailAsync(
                adminResult.Value,
                Id.CreateId(invokerResult.Value.UserId),
                emailResult.Value,
                cancellationToken);

            if (changeResult.IsFailure)
            {
                return changeResult;
            }
        }

        if (phoneNumberResult is not null)
        {
            var changeResult = await _phoneNumberChangeService.ChangeAdminPhoneNumberAsync(
                adminResult.Value,
                phoneNumberResult.Value,
                cancellationToken);

            if (changeResult.IsFailure)
            {
                return changeResult;
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
