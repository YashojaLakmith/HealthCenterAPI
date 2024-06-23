using Application.Abstractions.Events;

using Domain.ValueObjects;

using EventContacts.Contracts;

using MassTransit;

namespace EventContacts;
internal sealed class AdminCreaterEventPublisher : IAdminCreatedEventPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public AdminCreaterEventPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task Publish(AdminCreatedEvent newEvent, CancellationToken cancellationToken = default)
    {
        await _publishEndpoint.Publish(newEvent, cancellationToken);
    }

    public async Task PublishAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        await Publish(new(emailAddress), cancellationToken);
    }
}
