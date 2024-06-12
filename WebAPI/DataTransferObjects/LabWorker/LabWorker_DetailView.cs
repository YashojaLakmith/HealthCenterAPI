namespace WebAPI.DataTransferObjects.LabWorker;

public record LabWorker_DetaiView(
    string Title,
    string Name,
    string NIC,
    string PhoneNumber,
    string EmailAddress,
    string PictureToken,
    DateTime CreatedOn,
    DateTime LastSignIn
    );