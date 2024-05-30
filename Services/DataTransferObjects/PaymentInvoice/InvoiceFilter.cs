namespace Services.DataTransferObjects.PaymentInvoice;

public record InvoiceFilter(
    decimal ValueGreaterThan = 0,
    decimal ValueLessThan = int.MaxValue
    );