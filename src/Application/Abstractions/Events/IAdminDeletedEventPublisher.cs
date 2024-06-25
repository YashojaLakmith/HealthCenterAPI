using Domain.ValueObjects;

namespace Application.Abstractions.Events;

public interface IAdminDeletedEventPublisher
{
    Task PublishAsync(Id adminId, CancellationToken cancellationToken = default);
}