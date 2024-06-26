using Application.Abstractions.Invoker;
using EventContacts;
using MassTransit;
using Presentation;
using Serilog;
using Web.HttpContextUser;

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
        return services.AddMassTransit(busRegister =>
        {
            
            busRegister.SetKebabCaseEndpointNameFormatter();
            busRegister.AddConsumer<AdminCreatedEventConsumer>();

            busRegister.UsingRabbitMq((context, config) =>
            {
                config.Host(new Uri(configuration[@"RabbitMQ:Host"]!), options =>
                {
                    options.Username(configuration[@"RabbitMQ:Username"]!);
                    options.Password(configuration[@"RabbitMQ:Password"]!);
                });
                
                config.ConfigureEndpoints(context);
            });
        });
    }
}