namespace WebAPI;

public class Program
{
    public static async Task Main()
    {
        var builder = WebApplication.CreateBuilder();
        var env = builder.Environment;
        var services = builder.Services;

        services.AddControllers(o => o.SuppressAsyncSuffixInActionNames = false);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var app = builder.Build();
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

        await app.RunAsync();
    }
}
