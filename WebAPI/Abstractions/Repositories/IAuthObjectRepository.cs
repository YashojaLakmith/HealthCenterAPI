using WebAPI.Entities;

namespace WebAPI.Abstractions.Repositories;

public interface IAuthObjectRepository
{
    Task<PasswordAuthenticationObject> GetPasswordAuthenticationObjectAsync(string userId);
    Task UpdateSuccessfulAuthentication(PasswordAuthenticationObject passwordAuthenticationObject);
}
