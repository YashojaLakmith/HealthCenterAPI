using WebAPI.DataTransferObjects.Login;

namespace WebAPI.Abstractions.Services;
public interface IAuthServices
{
    Task<string?> HandleLoginAsync(LoginInformation loginInformation);
    Task HandleLogoutAsync(string token);
}