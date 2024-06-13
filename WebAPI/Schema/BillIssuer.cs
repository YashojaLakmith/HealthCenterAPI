namespace WebAPI.Schema;

public abstract class BillIssuer : ServerSideUser
{
    public ICollection<Bill> IssuedBills { get; set; }
}
