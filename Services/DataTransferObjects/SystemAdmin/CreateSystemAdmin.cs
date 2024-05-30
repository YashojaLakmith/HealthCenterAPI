namespace Services.DataTransferObjects.SystemAdmin;

public record CreateSystemAdmin(
    string Title,
    string Name,
    string NIC,
    string PhoneNumber,
    string EmailAddress,
    IReadOnlyCollection<uint> Roles
    );
