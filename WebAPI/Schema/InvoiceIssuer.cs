namespace WebAPI.Schema;

public abstract class InvoiceIssuer : ServerSideUser
{
    public ICollection<PaymentInvoice> IssuedInvoices { get; set; }
}
