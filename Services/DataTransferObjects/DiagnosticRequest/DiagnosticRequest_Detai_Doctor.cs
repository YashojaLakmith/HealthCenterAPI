using Services.DataTransferObjects.Common;

namespace Services.DataTransferObjects.DiagnosticRequest;

public record DiagnosticRequest_Detai_Doctor(
    string RequestId,
    Patient Patient,
    Diagnosys RequiredDiagnosys,
    DateTime IssuedDateTime,
    string Remarks,
    string RequestStatus
    );
