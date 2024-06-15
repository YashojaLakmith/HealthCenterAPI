using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public abstract class EmployeeBase
{
    [Key]
    public string EmployeeId { get; protected set; }
    public string EmployeeName { get; protected set; }
    public string NIC { get; protected set; }
    public string EmailAddress { get; protected set; }
    public string PhoneNumber { get; protected set; }
    public DateTime EmployeeCreatedOn { get; protected set; }

    public Genders Gender { get; protected set; }  
}
