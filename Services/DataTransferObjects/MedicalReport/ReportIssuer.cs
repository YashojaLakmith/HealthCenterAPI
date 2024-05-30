namespace Services.DataTransferObjects.MedicalReport;

public record ReportIssuer(
    string UserId,
    string UserName,
    string Designation
    );
