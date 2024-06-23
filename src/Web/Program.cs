using Application;
using Application.Authentication;
using AzureKeyVaultSecrets;
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
