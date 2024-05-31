using System.Security.Claims;

namespace WebAPI.Abstractions.JWT;

public interface IJwtHandler
{
    string CreateJwt(IEnumerable<Claim> claims);
    bool ValidateJwt(string token, out IEnumerable<Claim> claims);
    bool TryValidateAndRefreshToken(string token, out string newToken, out IEnumerable<Claim> claims);
}
