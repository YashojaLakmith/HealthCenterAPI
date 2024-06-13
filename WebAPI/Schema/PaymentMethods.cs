using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class PaymentMethods
{
    [Key]
    public string PaymentMethod { get; set; }

    public ICollection<PaymentInvoice> PaymentInvoices { get; set; }
}
