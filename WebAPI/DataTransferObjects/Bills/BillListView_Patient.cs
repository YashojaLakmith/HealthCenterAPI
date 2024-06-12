namespace WebAPI.DataTransferObjects.Bills;

public record BillListView_Patient(
    string BillId,
    DateTime IssuedDateTime,
    decimal Value,
    string PaymentStatus
    );
