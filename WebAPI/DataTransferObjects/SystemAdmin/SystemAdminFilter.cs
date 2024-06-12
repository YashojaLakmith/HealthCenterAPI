namespace WebAPI.DataTransferObjects.SystemAdmin;

public record SystemAdminFilter(
    IReadOnlyCollection<uint> Roles
    );
