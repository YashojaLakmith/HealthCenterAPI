using Services.DataTransferObjects.Common;

namespace Services.DataTransferObjects.DiagnosticRequest;

public record DiagnosticRequest_Detail(
    string RequestId,
    Doctor Doctor,
    Patient Patient,
    Diagnosys RequiredDiagnosys,
    DateTime IssuedDateTime,
    string Remarks,
    string RequestStatus
    );
