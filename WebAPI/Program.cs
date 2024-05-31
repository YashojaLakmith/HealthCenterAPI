using Microsoft.AspNetCore.Authentication;

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
        ConfigureServices(builder.Environment, builder.Services);
        var app = builder.Build();
        ConfigureMiddleware(builder.Environment, app);
        await app.RunAsync();
    }

    private static void ConfigureServices(IWebHostEnvironment environment, IServiceCollection services)
    {
        services.AddControllers(o => o.SuppressAsyncSuffixInActionNames = false);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAuthentication(JwtAuthenticationHandler.SchemeName)
            .AddScheme<AuthenticationSchemeOptions, JwtAuthenticationHandler>(JwtAuthenticationHandler.SchemeName, null);
        services.AddInMemorySecretCache();
        services.AddJwtSecrets();
        services.AddDbSecrets();

        if (environment.IsDevelopment())
        {
            services.AddDeveloperKeyStore();
        }
        else
        {
            services.AddAzureKeyVault();
        }

        services.AddJwtHandler(issueOptions =>
        {
            
        }, 
        validationOptions =>
        {
            
        });
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
    }}
