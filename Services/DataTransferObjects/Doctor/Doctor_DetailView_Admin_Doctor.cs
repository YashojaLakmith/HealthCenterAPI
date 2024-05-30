namespace Services.DataTransferObjects.Doctor;

public record Doctor_DetailView_Admin_Doctor(
    string Name,
    string NIC,
    string Title,
    string Specialization,
    string RegistrationNo,
    string PhoneNumber,
    string Email,
    string PictureToken,
    DateTime CreatedOn,
    DateTime LastSignIn
    );
