using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class Bill
{
    [Key]
    public string BillId { get; private set; }
    public string Description { get; private set; }
    public decimal BillValue { get; private set; }
    public DateTime BillCreatedOn { get; private set; }

    public PaymentInvoice? PaymentInvoice { get; private set; }
    public BillIssuer BillIssuedBy { get; private set; }
    public PatientBase Patient { get; private set; }

    public Bill() { }

    public static Bill CreateBill(IPayedService service, BillIssuer issuer, PatientBase patient)
    {
        return new Bill()
        {
            BillId = Guid.NewGuid().ToString(),
            Description = service.ServiceDescription,
            BillValue = service.ServicePrice,
            BillCreatedOn = DateTime.Now,
            BillIssuedBy = issuer,
            Patient = patient
        };
    }
}
