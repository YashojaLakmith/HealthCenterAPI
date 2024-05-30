namespace Services.DataTransferObjects.Patient;

public record CreateAssociativePatient(
    string PatientName,
    uint Gender,
    DateOnly BirthDate
    );