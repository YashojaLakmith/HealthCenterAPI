namespace Services.DataTransferObjects.DiagnosticRequest;

public record DiagnosticRequest_Detai_Patient(
    string RequestId,
    Common.Doctor Doctor,
    Diagnosys RequiredDiagnosys,
    DateTime IssuedDateTime,
    string Remarks,
    string RequestStatus
    );
