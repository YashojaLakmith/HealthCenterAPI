using Domain.ValueObjects;

namespace Application.Abstractions.Events;
public interface IAdminCreatedEventPublisher
{
    Task PublishAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default);
}
