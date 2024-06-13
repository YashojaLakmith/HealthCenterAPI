using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class Bill
{
    [Key]
    public string BillId { get; set; }
    public string Description { get; set; }
    public decimal BillValue { get; set; }
    public DateTime BillCreatedOn { get; set; }

    public PaymentInvoice? PaymentInvoice { get; set; }
    public BillIssuer BillIssuedBy { get; set; }
    public PatientBase Patient { get; set; }
}
