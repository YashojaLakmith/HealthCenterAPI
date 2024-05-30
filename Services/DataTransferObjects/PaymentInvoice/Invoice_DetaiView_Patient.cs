namespace Services.DataTransferObjects.PaymentInvoice;

public record Invoice_DetaiView_Patient(
    string InvoiceId,
    DateTime IssuedDateTime,
    decimal Amount,
    IReadOnlyCollection<BillCoverage> BillCoverage
    );
