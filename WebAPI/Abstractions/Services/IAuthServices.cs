using WebAPI.DataTransferObjects.Login;

namespace WebAPI.Abstractions.Services;
public interface IAuthServices
{
    Task<string?> HandlePatientLoginAsync(LoginInformation loginInformation);
    Task HandleLogoutAsync(string token);
}