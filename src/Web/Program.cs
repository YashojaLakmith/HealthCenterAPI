using Application;
using Application.Authentication;
using AzureKeyVaultSecrets;
using DistributedRedisCache;
using EventContacts;
using Infrastructure;
using Presentation;
using Repositories;

namespace Web;

public class Program
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
        services.AddApplication()
                .AddInfrastructure()
                .AddAdminAuthentication()
                .AddPresentation()
                .AddRepositories()
                .AddAzureKeyVault()
                .AddEvents()
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
                    
                })
                .AddHttpContextAccessor();
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
