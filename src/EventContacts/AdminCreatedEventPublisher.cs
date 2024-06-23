using Application.Abstractions.Events;
using Domain.ValueObjects;
using EventContacts.Contracts;
using MassTransit;

namespace EventContacts;
internal sealed class AdminCreatedEventPublisher : IAdminCreatedEventPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public AdminCreatedEventPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        await _publishEndpoint.Publish(new AdminCreatedEvent(emailAddress), cancellationToken);
    }
}
