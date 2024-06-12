namespace WebAPI.DataTransferObjects.Bills;

public record BillDetaiView_Patient(
    string BillId,
    string IssuedDepartment,
    IReadOnlyCollection<PaymentDescription> PaymentDescriptions,
    decimal Discounts,
    DateTime IssuedDateTime,
    string PaymentStatus
    )
{
    public decimal BillValue { get => PaymentDescriptions.Sum(x => x.ServiceFee) - Discounts; }
}
