namespace WebAPI.DataTransferObjects.Bills;

public record PaymentDescription(
    string Service,
    decimal ServiceFee
    );
