using Domain.Common;
using Domain.ValueObjects;

namespace Application.Authentication.Abstractions.Events;
public interface IAdminCreatedEventConsumer
{
    Task<Result> HandleConsumeAsync(EmailAddress emailAddress, CancellationToken cancellationToken);
}
