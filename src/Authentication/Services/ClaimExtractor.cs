using System.Security.Claims;

using Authentication.Entities;

namespace Authentication.Services;
internal static class ClaimExtractor
{
    internal static List<Claim> ExtractClaims(Credentials credentials)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, credentials.Admin.Id.Value.ToString()),
            new(ClaimTypes.Name, credentials.Admin.AdminName.Value),
            new(ClaimTypes.Role, credentials.Admin.Role.ToString())
        };

        return claims;
    }
}
