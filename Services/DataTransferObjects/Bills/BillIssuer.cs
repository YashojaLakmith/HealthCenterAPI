namespace Services.DataTransferObjects.Bills;

public record BillIssuer(
    string IssuerUserId,
    string IssuerName,
    string Designation,
    string Department
    );
