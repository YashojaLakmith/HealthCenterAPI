namespace WebAPI.Schema;

public class Pharmacist : BillIssuer
{
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }

    public ICollection<Prescription> IssuedPrescriptions { get; set; }
}
