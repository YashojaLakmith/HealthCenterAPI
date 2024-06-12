namespace WebAPI.DataTransferObjects.Common;

public record Patient(
    string PatientId,
    string PatientName,
    string Gender,
    uint Age
    );
