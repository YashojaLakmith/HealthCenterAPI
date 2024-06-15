namespace WebAPI.Schema;

public abstract class InvoiceIssuer : EmployeeBase
{
    public ICollection<PaymentInvoice> IssuedInvoices { get; set; }
}
