using Application.Abstractions.Events;
using Application.Authentication.Abstractions.Events;
using Microsoft.Extensions.DependencyInjection;

namespace EventContacts;

public static class DependencyInjection
{
    public static IServiceCollection AddEvents(this IServiceCollection services)
    {
        services.AddScoped<IAdminCreatedEventConsumer, AdminCreatedEventConsumer>();
        services.AddScoped<IAdminCreatedEventPublisher, AdminCreatedEventPublisher>();
        
        return services;
    }
}