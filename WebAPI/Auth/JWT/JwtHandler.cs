using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.IdentityModel.Tokens;
using WebAPI.Abstractions.JWT;
using WebAPI.Abstractions.Secrets;

namespace WebAPI.Auth.JWT;

public class JwtHandler : IJwtHandler
{
    private readonly JwtIssueOptions _jwtOptions;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly SigningCredentials _credentials;
    private readonly JwtSecurityTokenHandler _handler;
    private readonly ILogger<IJwtHandler> _logger;

    public JwtHandler(JwtIssueOptions jwtOptions, TokenValidationParameters validationParameters, IUserSecrets userSecrets, ILogger<IJwtHandler> logger)
    {
        _logger = logger;
        _jwtOptions = jwtOptions;
        _tokenValidationParameters = validationParameters;
        _credentials = ConfigureCredentials(userSecrets.GetJwtSigningKeyAsync(), SecurityAlgorithms.HmacSha256);
        _handler = new();
    }

    public string CreateJwt(IEnumerable<Claim> claims)
    {
        try
        {
            var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            expires: DateTime.Now.AddMinutes(_jwtOptions.ValidPeriodInMinutes),
            claims: claims,
            signingCredentials: _credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, null);
            throw;
        }
    }

    public bool ValidateJwt(string token, out IEnumerable<Claim> claims)
    {
        try
        {
            claims = _handler.ValidateToken(token, _tokenValidationParameters, out _).Claims;
            return true;
        }
        catch (Exception)
        {
            claims = [];
            return false;
        }
    }

    public bool TryValidateAndRefreshToken(string token, out string newToken, out IEnumerable<Claim> userClaims)
    {
        if(!ValidateJwt(token, out var claims))
        {
            userClaims = [];
            newToken = string.Empty;
            return false;
        }

        newToken = CreateJwt(claims);
        userClaims = claims;
        return true;
    }

    private SigningCredentials ConfigureCredentials(Task<byte[]> signingKeyTask, string algorithm)
    {
        try
        {
            var signingKey = GetSigningKey(signingKeyTask);
            var securityKey = new SymmetricSecurityKey(signingKey);
            return new SigningCredentials(securityKey, algorithm);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, null);
            throw;
        }
    }

    private static byte[] GetSigningKey(Task<byte[]> task)
    {
        task.Wait();
        if (task.IsFaulted)
        {
            throw task.Exception;
        }

        return task.Result;
    }
}

public static class JwtHandlerExtension
{
    public static IServiceCollection AddJwtHandler(this IServiceCollection services,
        Action<JwtIssueOptions> configureIssueOptions,
        Action<TokenValidationParameters> configureValidation)
    {
        services.AddSingleton<IJwtHandler>(o =>
        {
            var issueOptions = o.GetRequiredService<JwtIssueOptions>();
            var validationParams = o.GetRequiredService<TokenValidationParameters>();
            var secrets = o.GetRequiredService<IUserSecrets>();
            var logger = o.GetRequiredService<ILogger<IJwtHandler>>();

            configureIssueOptions(issueOptions);
            configureValidation(validationParams);
            return new JwtHandler(issueOptions, validationParams, secrets, logger);
        });

        return services;
    }
}
