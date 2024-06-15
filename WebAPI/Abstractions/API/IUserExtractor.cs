using WebAPI.Entities;

namespace WebAPI.Abstractions.API;

public interface IUserExtractor
{
    string GetUserId();
    Role GetRole();
}
