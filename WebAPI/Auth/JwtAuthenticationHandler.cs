using System.Security.Claims;
using System.Text.Encodings.Web;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using WebAPI.Abstractions.JWT;

namespace WebAPI.Auth;

public class JwtAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private const string SessionTokenHeader = @"X-SessionToken";
    private const string AuthHeaderName = @"Authorization";
    private readonly IJwtHandler _jwtHandler;

    public const string SchemeName = @"JWT_CUSTOM";

    public JwtAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        IJwtHandler jwtHandler) : base(options, logger, encoder)
    {
        _jwtHandler = jwtHandler;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var requestToken = ExtractToken(Request.Headers);

        if(requestToken is null)
        {
            return Task.FromResult(AuthenticateResult.Fail(@"Invalid session token."));
        }

        if(!_jwtHandler.TryValidateAndRefreshToken(requestToken, out var newToken, out var claims))
        {
            return Task.FromResult(AuthenticateResult.Fail(@"Invalid session token."));
        }

        var ticket = CreateAuthenticationTicket(claims);
        AppendTokenToResponse(newToken, Response.Headers);
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }

    private static string? ExtractToken(IHeaderDictionary headers)
    {
        if(!headers.TryGetValue(AuthHeaderName, out var reqToken))
        {
            return null;
        }

        var reqTokenSpan = reqToken.ToString();

        if (!reqTokenSpan.StartsWith(@"Bearer"))
        {
            return null;
        }

        var parts = reqTokenSpan.Split(@"Bearer", StringSplitOptions.TrimEntries);
        
        if(parts.Length == 2)
        {
            return parts[1];
        }

        return null;
    }

    private static void AppendTokenToResponse(string token, IHeaderDictionary headers)
    {
        headers.Append(SessionTokenHeader, token);
    }

    private static AuthenticationTicket CreateAuthenticationTicket(IEnumerable<Claim> claims)
    {
        var identity = new ClaimsIdentity(claims);
        var principal = new ClaimsPrincipal(identity);
        return new(principal, SchemeName);
    }
}
