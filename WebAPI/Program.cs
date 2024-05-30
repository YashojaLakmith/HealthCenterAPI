namespace WebAPI;

public class Program
{
    public static async Task Main()
    {
        var builder = WebApplication.CreateBuilder();
        ConfigureServices(builder.Services);
        var app = builder.Build();
        ConfigureMiddleware(builder.Environment, app);
        await app.RunAsync();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(o => o.SuppressAsyncSuffixInActionNames = false);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
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
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();
    }}
