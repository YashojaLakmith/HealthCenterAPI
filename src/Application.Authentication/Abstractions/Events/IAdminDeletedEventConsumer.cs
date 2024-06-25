using Domain.ValueObjects;

namespace Application.Authentication.Abstractions.Events;

public interface IAdminDeletedEventConsumer
{
    Task HandleConsumeAsync(Id adminId);
}