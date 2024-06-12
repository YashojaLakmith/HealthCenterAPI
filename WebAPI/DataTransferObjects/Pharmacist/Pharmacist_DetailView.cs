namespace WebAPI.DataTransferObjects.Pharmacist;

public record Pharmacist_DetailView(
    string PharmacistId,
    string Name,
    string Title,
    string NIC,
    string PhoneNumber,
    string EmailAddress,
    string PictureToken,
    DateTime CreatedOn,
    DateTime LastSignIn
    );
