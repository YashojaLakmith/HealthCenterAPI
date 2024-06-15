using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class PaymentInvoice
{
    [Key]
    public string InvoiceId { get; set; }
    public DateTime PaymentDate { get; set; }

    public PatientBase PaidPatient { get; set; }
    public InvoiceIssuer InvoiceIssuer { get; set; }
    public PaymentMethods PaymentMode { get; set; }
    public IReadOnlyCollection<Bill> Bills { get; set; }

    public PaymentInvoice() { }

    public static PaymentInvoice CreateInvoice(PatientBase payer, InvoiceIssuer issuer, PaymentMethods paymentMethod, IReadOnlyCollection<Bill> bills)
    {
        if(bills.Count == 0)
        {

        }

        return new PaymentInvoice()
        {
            InvoiceId = Guid.NewGuid().ToString(),
            PaymentDate = DateTime.Now,
            PaidPatient = payer,
            PaymentMode = paymentMethod,
            InvoiceIssuer = issuer,
            Bills = [.. bills]
        };
    }
}
