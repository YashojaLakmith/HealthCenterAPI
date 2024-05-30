namespace Services.DataTransferObjects.Payment;

public record CardPayment(
    string AuthorizationCode,
    decimal Amount,
    string TimeStamp,
    uint CardNumberLast4Digits
    );
