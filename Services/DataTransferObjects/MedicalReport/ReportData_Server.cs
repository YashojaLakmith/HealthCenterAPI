using Services.DataTransferObjects.Common;

namespace Services.DataTransferObjects.MedicalReport;

public record ReportData_Server(
    string ReportId,
    string DiagnosticRequestId,
    Patient Patient,
    Doctor Doctor,
    ReportIssuer ReportIssuer,
    DateTime IssuedDateTime,
    string ReportAcceptance
    );
