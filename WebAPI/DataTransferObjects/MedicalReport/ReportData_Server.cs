namespace WebAPI.DataTransferObjects.MedicalReport;

public record ReportData_Server(
    string ReportId,
    string DiagnosticRequestId,
    Common.Patient Patient,
    Common.Doctor Doctor,
    ReportIssuer ReportIssuer,
    DateTime IssuedDateTime,
    string ReportAcceptance
    );
