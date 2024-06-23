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
        return services.AddScoped<ICommandQueryInvoker, HttpActionInvoker>();
    }

    public static IServiceCollection ConfigureMassTransit(this IServiceCollection services)
    {
        return services.AddMassTransit(busRegister =>
        {
            busRegister.AddConsumer<AdminCreatedEventConsumer>();

            busRegister.UsingRabbitMq((context, config) =>
            {
                config.ConfigureEndpoints(context);
            });
        });
    }
}