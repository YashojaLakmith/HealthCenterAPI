using System.Security.Claims;
using System.Text.Encodings.Web;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using WebAPI.Abstractions.JWT;

namespace WebAPI.Auth;

public class JwtAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IJwtHandler _jwtHandler;
    private const string AuthHeaderName = @"Authorization";

    public const string SchemeName = @"JWT_CUSTOM";
    public const string SessionTokenHeader = @"X-SessionToken";
    public const string SessionCookieName = @"Session";

    public JwtAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        IJwtHandler jwtHandler) : base(options, logger, encoder)
    {
        _jwtHandler = jwtHandler;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if(TryExtractBearerToken(out var bearerToken))
        {
            return HandleBearerAuthenticationAsync(bearerToken);
        }

        if(TryExtractSessionCookie(out var sessionCookie))
        {
            return HandleCookieAuthenticationAsync(sessionCookie);
        }

        var failedResult = AuthenticateResult.Fail(@"Could not find valid bearer token or session cookie.");
        return Task.FromResult(failedResult);
    }

    private bool TryExtractBearerToken(out string token)
    {
        const int bearerLength = 7;
        token = @"";
        if(!Request.Headers.TryGetValue(AuthHeaderName, out var authHeader))
        {
            return false;
        }

        ReadOnlySpan<char> authHeaderAsSpan = authHeader.ToString();

        if(authHeaderAsSpan.Length <= bearerLength)
        {
            return false;
        }

        var slice = authHeaderAsSpan[..7];
        if(!slice.Equals(@"Bearer "))
        {
            return false;
        }

        token = authHeaderAsSpan[7..].ToString();
        return true;
    }

    private Task<AuthenticateResult> HandleBearerAuthenticationAsync(string bearerToken)
    {
        if (!_jwtHandler.TryValidateAndRefreshToken(bearerToken, out var newToken, out var claims))
        {
            return Task.FromResult(AuthenticateResult.Fail(@"Could not authenticate the provided bearer token."));
        }

        var ticket = CreateAuthenticationTicket(claims);
        Response.Headers.Append(SessionTokenHeader, newToken);
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }

    private bool TryExtractSessionCookie(out string cookie)
    {
        if(!Request.Cookies.TryGetValue(SessionCookieName, out cookie))
        {
            return false;
        }

        return true;
    }

    private Task<AuthenticateResult> HandleCookieAuthenticationAsync(string sessionCookie)
    {
        if (!_jwtHandler.TryValidateAndRefreshToken(sessionCookie, out var newToken, out var claims))
        {
            return Task.FromResult(AuthenticateResult.Fail(@"Could not authenticate the session token."));
        }

        var ticket = CreateAuthenticationTicket(claims);
        Response.Cookies.Append(SessionCookieName, newToken);
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }

    private static AuthenticationTicket CreateAuthenticationTicket(IEnumerable<Claim> claims)
    {
        var identity = new ClaimsIdentity(claims);
        var principal = new ClaimsPrincipal(identity);
        return new(principal, SchemeName);
    }
}