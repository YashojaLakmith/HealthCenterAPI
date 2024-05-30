namespace Services.DataTransferObjects.MedicalReport;

public record ReportData_Patient(
    string ReportId,
    DateTime IssuedDateTime
    );
