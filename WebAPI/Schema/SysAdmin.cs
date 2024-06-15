namespace WebAPI.Schema;

public class SysAdmin : EmployeeBase
{
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }

    public ICollection<AdminRoles> Roles { get; set; }

    public void AddNewRole(AdminRoles role)
    {
        if(!Roles.Any(r => r.RoleId.Equals(role.RoleId)))
        {
            Roles.Add(role);
        }
    }

    public void RemoveRole(AdminRoles role)
    {
        if(Roles.Any(r => r.RoleId.Equals(role.RoleId)))
        {
            Roles.Remove(role);
        }
    }
}
