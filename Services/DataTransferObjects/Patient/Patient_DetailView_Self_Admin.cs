namespace Services.DataTransferObjects.Patient;

public record Patient_DetailView_Self_Admin(
    string PatientId,
    string NIC,
    uint Gender,
    DateOnly BirthDate,
    string PhoneNumber,
    string EmailAddress,
    bool IsAssociative
    );
