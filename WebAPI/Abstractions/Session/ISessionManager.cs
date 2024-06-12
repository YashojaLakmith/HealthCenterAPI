using System.Security.Claims;

namespace WebAPI.Abstractions.Session;

public interface ISessionManager
{
    Task<string> CreateTokenAsync(IEnumerable<Claim> claims);
    Task<IEnumerable<Claim>?> GetClaimsAsync(string token);
    Task RevokeTokenAsync(string token);
}