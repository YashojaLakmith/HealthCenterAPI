using Application;
using Application.Authentication;
using Authentication;
using AzureKeyVaultSecrets;
using DistributedRedisCache;
using Domain;
using EventContacts;
using Infrastructure;
using Presentation;
using Repositories;

namespace Web;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services, builder.Environment);
        var app = builder.Build();
        ConfigureMiddleware(app, builder.Environment);
        await app.RunAsync();
    }

    private static void ConfigureServices(IServiceCollection services, IWebHostEnvironment environment)
    {
        var presentationAssembly = typeof(PresentationAssembly).Assembly;
        
        services.AddDomain()
            .AddApplication()
            .AddInfrastructure()
            .AddAuthenticationDomain()
            .AddAdminAuthentication()
            .AddRepositories()
            .AddAzureKeyVault()
            .AddEvents()
            .AddPresentation()
            .ConfigureLogging()
            .ConfigureInvoker()
            .ConfigureMassTransit()
            .AddDistributedTokenStoring(resetTokenConfig =>
            {
                resetTokenConfig.SlidingExpiration = TimeSpan.FromMinutes(15);
            }, sessionTokenConfig =>
            {
                sessionTokenConfig.SlidingExpiration = TimeSpan.FromMinutes(45);
            }, resetCacheOptions =>
            {

            }, sessionCacheOptions =>
            {

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
