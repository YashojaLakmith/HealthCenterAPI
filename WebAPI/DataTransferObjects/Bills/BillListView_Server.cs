namespace WebAPI.DataTransferObjects.Bills;

public record BillListView_Server(
    string BillId,
    string UserId,
    DateTime IssuedDateTime,
    decimal Value,
    string PaymentStatus
    );
