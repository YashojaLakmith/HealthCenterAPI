namespace WebAPI.DataTransferObjects.LabWorker;

public record CreateLabWorker(
    string Title,
    string Name,
    string NIC,
    string PhoneNumber,
    string EmailAddress
    );