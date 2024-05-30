namespace Services.DataTransferObjects.SystemAdmin;

public record SystemAdminFilter(
    IReadOnlyCollection<uint> Roles
    );
