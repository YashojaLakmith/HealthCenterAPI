using System.Security.Claims;

using WebAPI.Abstractions.API;
using WebAPI.Entities;

namespace WebAPI.User;

public class HttpContextUserInformation : IUserExtractor
{
    private readonly IHttpContextAccessor _accessor;

    public HttpContextUserInformation(IHttpContextAccessor contextAccessor)
    {
        _accessor = contextAccessor;
    }

    public Role GetRole()
    {
        var claims = GetClaims();
        var claim = claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Role));

        return claim is null ? throw new InvalidOperationException() : (Role)int.Parse(claim.Value);
    }

    public string GetUserId()
    {
        var claims = GetClaims();
        var claim = claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier));

        return claim is null ? throw new InvalidOperationException() : claim.Value;
    }

    private IEnumerable<Claim> GetClaims()
    {
        var context = _accessor.HttpContext;
        return context is null ? throw new InvalidOperationException(@"No HTTP Context.") : context.User.Claims;
    }
}

public static class UserInfoExtractorExtensions
{
    public static void AddUserInfoExtractor(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IUserExtractor, HttpContextUserInformation>();
    }
}
