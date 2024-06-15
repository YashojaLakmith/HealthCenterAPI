using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class AdminRoles
{
    [Key]
    public int RoleId { get; set; }
    public string Description { get; set; }

    public IReadOnlyCollection<SysAdmin> Admins { get; set; }

    public AdminRoles() { }

    public static AdminRoles CreateNewRole(int roleId, string description)
    {
        return new AdminRoles()
        {
            RoleId = roleId,
            Description = description,
            Admins = []
        };
    }
}
