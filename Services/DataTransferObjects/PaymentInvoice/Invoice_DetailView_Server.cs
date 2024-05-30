namespace Services.DataTransferObjects.PaymentInvoice;

public record Invoice_DetailView_Server(
    string InvoiceId,
    string PatientId,
    string IssuerId,
    DateTime IssuedDateTime,
    decimal Amount,
    IReadOnlyCollection<BillCoverage> BillCoverage
    );
