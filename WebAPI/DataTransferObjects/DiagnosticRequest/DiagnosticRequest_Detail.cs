namespace WebAPI.DataTransferObjects.DiagnosticRequest;

public record DiagnosticRequest_Detail(
    string RequestId,
    Common.Doctor Doctor,
    Common.Patient Patient,
    Diagnosys RequiredDiagnosys,
    DateTime IssuedDateTime,
    string Remarks,
    string RequestStatus
    );
