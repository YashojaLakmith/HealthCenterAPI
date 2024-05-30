namespace Services.DataTransferObjects.Bills;

public record PaymentDescription(
    string Service,
    decimal ServiceFee
    );
