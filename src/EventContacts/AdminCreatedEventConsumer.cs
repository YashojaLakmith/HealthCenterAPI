using Application.Authentication.Abstractions.Events;

using Authentication.Entities;
using Authentication.Repositories;

using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

using EventContacts.Contracts;

using MassTransit;

namespace EventContacts;
internal sealed class AdminCreatedEventConsumer : IAdminCreatedEventConsumer, IConsumer<AdminCreatedEvent>
{
    private readonly IAdminRepository _adminRepository;
    private readonly ICredentialRepository _credentialRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AdminCreatedEventConsumer(IAdminRepository adminRepository, ICredentialRepository credentialRepository, IUnitOfWork unitOfWork)
    {
        _adminRepository = adminRepository;
        _credentialRepository = credentialRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<AdminCreatedEvent> context)
    {
        await HandleConsumeAsync(context.Message.AdminEmailAddress);
    }

    public async Task<Result> HandleConsumeAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        var adminResult = await _adminRepository.GetByEmailAsync(emailAddress, cancellationToken);
        if (adminResult.IsFailure)
        {
            return adminResult;
        }

        var newCredentials = Credentials.CreateCredentials(adminResult.Value);
        await _credentialRepository.InsertNewAsync(newCredentials, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
