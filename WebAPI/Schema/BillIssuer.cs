namespace WebAPI.Schema;

public abstract class BillIssuer : EmployeeBase
{
    public ICollection<Bill> IssuedBills { get; set; }
}
