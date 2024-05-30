namespace Services.DataTransferObjects.Bills;

public record BillDetaiView_Server(
    string BillId,
    string UserId,
    BillIssuer Issuer,
    IReadOnlyCollection<PaymentDescription> PaymentDescriptions,
    decimal Discount,
    DateTime IssuedDateTime,
    string PaymentStatus
    )
{
    public decimal BillValue { get => PaymentDescriptions.Sum(x => x.ServiceFee) - Discount; }
}
