namespace WebAPI.DataTransferObjects.DiagnosticRequest;

public record DiagnosticRequest_ListView(
    string RequestId,
    DateTime IssuedDateTime,
    string Status
    );
