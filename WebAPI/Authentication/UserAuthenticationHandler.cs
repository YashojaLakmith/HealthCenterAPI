using System.Security.Claims;
using System.Text.Encodings.Web;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

using WebAPI.Abstractions.Session;

namespace WebAPI.Authentication;

public class UserAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public const string SchemeName = @"Session based authentication handler";
    public const string SessionCookieName = @"Session";

    private const string AuthHeaderName = @"Authorization";

    private readonly ISessionManager _tokenManager;

    public UserAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISessionManager tokenManager) : base(options, logger, encoder)
    {
        _tokenManager = tokenManager;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (TryExtractSessionCookie(out var sessionCookie))
        {
            return await HandleCookieAuthenticationAsync(sessionCookie);
        }

        if (TryExtractBearerToken(out var bearerToken))
        {
            return await HandleBearerAuthenticationAsync(bearerToken);
        }

        return AuthenticateResult.Fail(@"Could not find valid bearer token or session cookie.");
    }

    private bool TryExtractBearerToken(out string token)
    {
        const int bearerLength = 7;
        token = @"";
        if (!Request.Headers.TryGetValue(AuthHeaderName, out var authHeader))
        {
            return false;
        }

        ReadOnlySpan<char> authHeaderAsSpan = authHeader.ToString();

        if (authHeaderAsSpan.Length <= bearerLength)
        {
            return false;
        }

        var slice = authHeaderAsSpan[..7];
        if (!slice.Equals(@"Bearer "))
        {
            return false;
        }

        token = authHeaderAsSpan[7..].ToString();
        return true;
    }

    private async Task<AuthenticateResult> HandleBearerAuthenticationAsync(string bearerToken)
    {
        var claims = await _tokenManager.GetClaimsAsync(bearerToken);

        if(claims is null)
        {
            return AuthenticateResult.Fail(@"Could not authenticate the bearer token.");
        }

        var ticket = CreateAuthenticationTicket(claims);
        return AuthenticateResult.Success(ticket);
    }

    private bool TryExtractSessionCookie(out string cookie)
    {
        if (!Request.Cookies.TryGetValue(SessionCookieName, out cookie))
        {
            return false;
        }

        return true;
    }

    private async Task<AuthenticateResult> HandleCookieAuthenticationAsync(string sessionCookie)
    {
        var claims = await _tokenManager.GetClaimsAsync(sessionCookie);

        if(claims is null)
        {
            return AuthenticateResult.Fail(@"Could not authenticate the session.");
        }

        var ticket = CreateAuthenticationTicket(claims);
        return AuthenticateResult.Success(ticket);
    }

    private static AuthenticationTicket CreateAuthenticationTicket(IEnumerable<Claim> claims)
    {
        var identity = new ClaimsIdentity(claims);
        var principal = new ClaimsPrincipal(identity);
        return new(principal, SchemeName);
    }
}
