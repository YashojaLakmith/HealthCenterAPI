using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class PaymentMethods
{
    [Key]
    public string PaymentMethod { get; set; }

    public ICollection<PaymentInvoice> PaymentInvoices { get; set; }

    public override bool Equals(object? obj)
    {
        if(obj is PaymentMethods p)
        {
            return GetHashCode() == p.GetHashCode() && PaymentMethod.Equals(p.PaymentMethod, StringComparison.OrdinalIgnoreCase);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return PaymentMethod.GetHashCode();
    }
}
