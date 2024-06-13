namespace WebAPI.Schema;

public class SysAdmin : ServerSideUser
{
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }

    public ICollection<AdminRoles> Roles { get; set; }
}
