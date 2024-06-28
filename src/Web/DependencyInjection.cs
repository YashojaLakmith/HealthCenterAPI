using Application.Abstractions.Invoker;
using EventContacts;
using MassTransit;
using Microsoft.AspNetCore.Authentication;
using Presentation;
using Serilog;
using Web.HttpContextUser;
using Web.WebAPIAuthentication;

namespace Web;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false)
            .AddApplicationPart(typeof(PresentationAssembly).Assembly);
        return services;
    }

    public static IServiceCollection ConfigureLogging(this IServiceCollection services)
    {
        return services.AddLogging(conf =>
        {
            conf.AddConsole()
                .AddSerilog(dispose: true);
        });
    }

    public static IServiceCollection ConfigureInvoker(this IServiceCollection services)
    {
        return services
            .AddHttpContextAccessor()
            .AddScoped<ICommandQueryInvoker, HttpActionInvoker>();
    }

    public static IServiceCollection ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        var uri = Environment.GetEnvironmentVariable(@"RABBITMQ_URI")!;
        var user = Environment.GetEnvironmentVariable(@"RABBITMQ_USER")!;
        var password = Environment.GetEnvironmentVariable(@"RABBITMQ_PASSWORD")!;
        
        return services.AddMassTransit(busRegister =>
        {
            
            busRegister.SetKebabCaseEndpointNameFormatter();
            busRegister.AddConsumer<AdminCreatedEventConsumer>();

            busRegister.UsingRabbitMq((context, config) =>
            {
                config.Host(new Uri(uri), options =>
                {
                    options.Username(user);
                    options.Password(password);
                });
                
                config.ConfigureEndpoints(context);
            });
        });
    }

    public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(AdminAuthenticationHandler.SchemeName)
            .AddScheme<AuthenticationSchemeOptions, AdminAuthenticationHandler>(
                AdminAuthenticationHandler.SchemeName,
                null);

        return services;
    }
}