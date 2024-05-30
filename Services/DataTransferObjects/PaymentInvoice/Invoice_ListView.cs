namespace Services.DataTransferObjects.PaymentInvoice;

public record Invoice_ListView(
    string InvoiceId,
    DateTime IssuedDateTime
    );
