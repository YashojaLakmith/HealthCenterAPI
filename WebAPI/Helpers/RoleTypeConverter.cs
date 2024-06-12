using WebAPI.Entities;

namespace WebAPI.Helpers;

public class RoleTypeConverter
{
    public static Role ConvertToGenericRole(Role role)
    {
        return role & (Role) 255;
    }
}
