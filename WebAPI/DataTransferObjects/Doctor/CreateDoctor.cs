namespace WebAPI.DataTransferObjects.Doctor;

public record CreateDoctor(
    string Name,
    string NIC,
    string Title,
    string Specialization,
    string RegistrationNo,
    string PhoneNumber,
    string Email
    );
