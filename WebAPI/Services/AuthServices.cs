using WebAPI.Abstractions.Repositories;
using WebAPI.Abstractions.Services;
using WebAPI.Abstractions.Session;
using WebAPI.DataTransferObjects.Login;

namespace WebAPI.Services;

public class AuthServices : IAuthServices
{
    private readonly IAuthObjectRepository _authRepository;
    private readonly ISessionManager _tokenManager;

    public AuthServices(IAuthObjectRepository authRepository, ISessionManager tokenManager)
    {
        _authRepository = authRepository;
        _tokenManager = tokenManager;
    }

    public async Task<string?> HandleLoginAsync(LoginInformation loginInformation)
    {
        var authObject = await _authRepository.GetPasswordAuthenticationObjectAsync(loginInformation.UserId);
        if (!authObject.TryAuthenticate(loginInformation, out var claims))
        {
            return null;
        }

        var token = await _tokenManager.CreateTokenAsync(claims);
        await _authRepository.UpdateSuccessfulAuthentication(authObject);
        return token;
    }

    public async Task HandleLogoutAsync(string token)
    {
        await _tokenManager.RevokeTokenAsync(token);
    }
}

public static class AuthServiceExtensions
{
    public static void AddAuthSevices(this IServiceCollection services)
    {
        services.AddScoped<IAuthServices, AuthServices>();
    }
}
