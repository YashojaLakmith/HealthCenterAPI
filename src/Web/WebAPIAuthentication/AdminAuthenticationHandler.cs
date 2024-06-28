using System.Security.Claims;
using System.Text.Encodings.Web;
using Authentication.Abstractions.Services;
using Authentication.ValueObjects;
using Domain.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Web.WebAPIAuthentication;

public sealed class AdminAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly ISessionVerificationService _sessionVerificationService;

    public const string SchemeName = nameof(AdminAuthenticationHandler);

    public AdminAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder, 
        ISessionVerificationService sessionVerificationService) 
        : base(options, logger, encoder)
    {
        _sessionVerificationService = sessionVerificationService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (Request.Cookies.TryGetValue(nameof(SessionToken), out var cookieToken))
        {
            return await TryAuthenticateTheTokenAsync(cookieToken);
        }

        return await TryAuthenticateWithBearerTokenAsync();
    }
    
    private async Task<AuthenticateResult> TryAuthenticateTheTokenAsync(string token)
    {
        var tokenResult = SessionToken.CreateToken(token);
        if (tokenResult.IsFailure)
        {
            return AuthenticateResult.Fail(tokenResult.Error.Description);
        }

        var claimResult = await _sessionVerificationService.GetClaimsAsync(tokenResult.Value);
        if (claimResult.IsFailure)
        {
            return AuthenticateResult.Fail(claimResult.Error.Description);
        }

        var extendResult = await _sessionVerificationService.ExtendSessionAsync(tokenResult.Value);
        if (extendResult.IsFailure)
        {
            return AuthenticateResult.Fail(extendResult.Error.Description);
        }

        var identity = new ClaimsIdentity(claimResult.Value);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, SchemeName);
        
        return AuthenticateResult.Success(ticket);
    }

    private async Task<AuthenticateResult> TryAuthenticateWithBearerTokenAsync()
    {
        const string headerName = @"Authorization";
        if (!Request.Headers.TryGetValue(headerName, out var bearerToken))
        {
            return AuthenticateResult.Fail(@"Could not find bearer token.");
        }

        var tokenResult = ExtractToken(bearerToken.ToString());
        if (tokenResult.IsFailure)
        {
            return AuthenticateResult.Fail(tokenResult.Error.Description);
        }

        return await TryAuthenticateTheTokenAsync(tokenResult.Value);
    }

    private static Result<string> ExtractToken(ReadOnlySpan<char> bearerToken)
    {
        const string bearer = @"Bearer ";
        if (bearerToken.Length <= bearer.Length + 1)
        {
            return Result<string>.Failure(new Error(@"SessionToken", @"Invalid bearer token."));
        }
        
        var phase = bearerToken[..bearer.Length];

        if (!phase.Equals(bearer, StringComparison.Ordinal))
        {
            return Result<string>.Failure(new Error(@"SessionToken", @"Invalid bearer token."));
        }

        var length = bearerToken.Length - bearer.Length;
        var token = bearerToken.Slice(bearer.Length, length);
        return new string(token);
    }
}