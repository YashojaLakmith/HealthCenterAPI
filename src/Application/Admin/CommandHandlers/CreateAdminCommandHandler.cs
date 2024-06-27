using Application.Abstractions.CQRS;
using Application.Abstractions.Events;
using Application.Abstractions.Invoker;
using Application.Admin.Commands;
using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Admin.CommandHandlers;
internal class CreateAdminCommandHandler : ICommandHandler<CreateAdminCommand>
{
    private readonly IAdminCreatedEventPublisher _eventPublisher;
    private readonly ICreateUserService _createUserService;
    private readonly ICommandQueryInvoker _invoker;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAdminCommandHandler(IAdminCreatedEventPublisher eventPublisher, ICreateUserService createUserService, ICommandQueryInvoker invoker, IUnitOfWork unitOfWork)
    {
        _eventPublisher = eventPublisher;
        _createUserService = createUserService;
        _invoker = invoker;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(CreateAdminCommand command, CancellationToken cancellationToken = default)
    {
        var emailResult = EmailAddress.CreateEmailAddress(command.EmailAddress);
        if (emailResult.IsFailure)
        {
            return emailResult;
        }

        var nameResult = Name.Create(command.UserName);
        if (nameResult.IsFailure)
        {
            return nameResult;
        }

        var nicResult = NIC.Create(command.NIC);
        if (nicResult.IsFailure)
        {
            return nicResult;
        }

        var phoneNumberResult = PhoneNumber.CreatePhoneNumber(command.PhoneNumber);
        if (phoneNumberResult.IsFailure)
        {
            return phoneNumberResult;
        }

        var invokerResult = await _invoker.GetInvokingUserAsync(cancellationToken);
        if (invokerResult.IsFailure)
        {
            return invokerResult;
        }

        var creationResult = await _createUserService.CreateAdminAsync(
            nameResult.Value,
            command.Role,
            nicResult.Value,
            command.Gender,
            emailResult.Value,
            phoneNumberResult.Value,
            Id.CreateId(invokerResult.Value.UserId),
            cancellationToken);

        if (creationResult.IsFailure)
        {
            return creationResult;
        }

        var saveResult = await _unitOfWork.SaveChangesAsync(cancellationToken);
        if (saveResult.IsFailure)
        {
            return saveResult;
        }
        
        await _eventPublisher.PublishAsync(emailResult.Value, cancellationToken);
        return Result.Success();
    }
}
