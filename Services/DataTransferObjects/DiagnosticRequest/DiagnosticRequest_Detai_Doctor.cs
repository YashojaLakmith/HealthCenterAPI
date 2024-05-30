namespace Services.DataTransferObjects.DiagnosticRequest;

public record DiagnosticRequest_Detai_Doctor(
    string RequestId,
    Common.Patient Patient,
    Diagnosys RequiredDiagnosys,
    DateTime IssuedDateTime,
    string Remarks,
    string RequestStatus
    );
