using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;

using WebAPI.Auth;
using WebAPI.Auth.JWT;
using WebAPI.MemoryStore;
using WebAPI.Secrets;

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
        ConfigureSecretsAndKeyVault(services, isDevelopmentEnv);
        ConfigureSwaggerGen(services);
        ConfigureAuthentication(services);
        ConfigureKeyVault(services, isDevelopmentEnv);
        ConfigureJwtHandler(services);
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
        services.AddAuthentication(JwtAuthenticationHandler.SchemeName)
            .AddScheme<AuthenticationSchemeOptions, JwtAuthenticationHandler>(JwtAuthenticationHandler.SchemeName, null);
    }

    private static void ConfigureJwtHandler(IServiceCollection services)
    {
        services.AddJwtHandler(ConfigureJwtIssueOptions, ConfigureTokenValidationOptions);
    }

    private static void ConfigureJwtIssueOptions(JwtIssueOptions issueOptions)
    {

    }

    private static void ConfigureTokenValidationOptions(TokenValidationParameters tokenValidation)
    {
        
    }
}
