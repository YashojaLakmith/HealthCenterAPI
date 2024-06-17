using Web.Configure;

namespace Web;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.RegisterServices(builder.Environment);
        var app = builder.Build();
        app.ConfigureMiddleWare(builder.Environment);
        await app.RunAsync();
    }
}
