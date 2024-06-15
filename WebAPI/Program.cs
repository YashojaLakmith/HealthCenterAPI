using Microsoft.AspNetCore.Authentication;

using WebAPI.Authentication;
using WebAPI.EF;
using WebAPI.MemoryStore;
using WebAPI.Secrets;
using WebAPI.Services;
using WebAPI.Session;

namespace WebAPI;

public class Program
{
    public static async Task Main()
    {
        var builder = WebApplication.CreateBuilder();
        ConfigureServiceContainer(builder.Environment, builder.Services);
        var app = builder.Build();
        ConfigureMiddleware(builder.Environment, app);
        await app.RunAsync();
    }

    private static void ConfigureServiceContainer(IWebHostEnvironment environment, IServiceCollection services)
    {
        var isDevelopmentEnv = environment.IsDevelopment();

        ConfigureControllers(services);
        ConfigureSessions(services);
        ConfigureSecretsAndKeyVault(services, isDevelopmentEnv);
        ConfigureSwaggerGen(services);
        ConfigureAuthentication(services);
        ConfigureKeyVault(services, isDevelopmentEnv);
        AddDatabase(services);
        ConfigureServices(services);
    }

    private static void ConfigureMiddleware(IWebHostEnvironment env, WebApplication app)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();

            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint(@"/swagger/v1/swagger.json", @"v1");
                o.RoutePrefix = string.Empty;
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();
    }

    private static void ConfigureControllers(IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.SuppressAsyncSuffixInActionNames = false;
        });
    }

    private static void ConfigureSessions(IServiceCollection services)
    {
        services.AddTokenBasedSessions(options =>
        {
            
        });

        services.AddRedisSessionCache(options =>
        {
            
        });
    }

    private static void ConfigureSecretsAndKeyVault(IServiceCollection services, bool isDevelopmentEnv)
    {
        services.AddInMemorySecretCache();
        services.AddJwtSecrets();
        services.AddDbSecrets();
        ConfigureKeyVault(services, isDevelopmentEnv);
    }

    private static void ConfigureKeyVault(IServiceCollection services, bool isDevelopmentEnvironment)
    {
        if (isDevelopmentEnvironment)
        {
            services.AddDeveloperKeyStore();
        }
        else
        {
            services.AddAzureKeyVault();
        }
    }

    private static void ConfigureSwaggerGen(IServiceCollection services)
    {
        services.AddSwaggerGen();
    }

    private static void ConfigureAuthentication(IServiceCollection services)
    {
        services.AddAuthentication(UserAuthenticationHandler.SchemeName)
            .AddScheme<AuthenticationSchemeOptions, UserAuthenticationHandler>(UserAuthenticationHandler.SchemeName, null);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthSevices();
    }

    private static void AddDatabase(IServiceCollection services)
    {
        services.AddEFCore();
    }
}
