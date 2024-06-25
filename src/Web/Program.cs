using Application;
using Application.Authentication;
using Authentication;
using AzureKeyVaultSecrets;
using DistributedRedisCache;
using Domain;
using EventContacts;
using Infrastructure;
using Infrastructure.Abstractions;
using Presentation;
using Repositories;
using Web.LocalDev;

namespace Web;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services, builder.Environment, builder.Configuration);
        var app = builder.Build();
        ConfigureMiddleware(app, builder.Environment);
        await app.RunAsync();
    }

    private static void ConfigureServices(IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
    {
        if (environment.IsDevelopment())
        {
            services.AddSingleton<IDbConnectionStringSource, ConnectionStringProvider>();
        }
        
        services.AddDomain()
            .AddApplication()
            .AddInfrastructure()
            .AddAuthenticationDomain()
            .AddAdminAuthentication()
            .AddRepositories()
     //       .AddAzureKeyVault()
            .AddEvents()
            .AddPresentation()
            .ConfigureLogging()
            .ConfigureInvoker()
            .ConfigureMassTransit(configuration)
            .AddDistributedTokenStoring(resetTokenConfig =>
            {
                var expirationMinutes = double.Parse(configuration[@"ResetTokenCache:SlidingExpirationMinutes"]!);
                resetTokenConfig.SlidingExpiration = TimeSpan.FromMinutes(expirationMinutes);
            }, sessionTokenConfig =>
            {
                var expirationMinutes = double.Parse(configuration[@"SessionTokenCache:SlidingExpirationMinutes"]!);
                sessionTokenConfig.SlidingExpiration = TimeSpan.FromMinutes(expirationMinutes);
            }, resetCacheOptions =>
            {
                resetCacheOptions.InstanceName = configuration[@"ResetTokenCache:Name"]!;
            }, sessionCacheOptions =>
            {
                sessionCacheOptions.InstanceName = configuration[@"SessionCache:Name"]!;
            });
    }

    private static void ConfigureMiddleware(WebApplication app, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();
    }
}
