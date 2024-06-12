namespace WebAPI.DataTransferObjects.SystemAdmin;

public record SystemAdmin_DetailView_Privileged(
    string SystemAdminId,
    string Title,
    string Name,
    string NIC,
    string PhoneNumber,
    string EmailAddress,
    string PicureToken,
    IReadOnlyCollection<uint> Roles
    );
