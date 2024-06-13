using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class AdminRoles
{
    [Key]
    public int RoleId { get; set; }
    public string Description { get; set; }

    public ICollection<SysAdmin> Admins { get; set; }
}
