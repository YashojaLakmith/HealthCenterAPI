using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class PaymentInvoice
{
    [Key]
    public string InvoiceId { get; set; }
    public ICollection<Bill> Bills { get; set; }
    public DateTime PaymentDate { get; set; }

    public PatientBase PaidPatient { get; set; }
    public InvoiceIssuer InvoiceIssuer { get; set; }
    public PaymentMethods PaymentMode { get; set; }
}
