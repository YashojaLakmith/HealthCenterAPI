namespace WebAPI.DataTransferObjects.Patient;

public record CreateNewPatient(
    string NIC,
    uint Gender,
    DateOnly BirthDate,
    string PhoneNumber,
    string EmailAddress
    );
