namespace Services.DataTransferObjects.SystemAdmin;

public record SystemAdmin_DetailView_UnPrivileged(
    string SystemAdminId,
    string Title,
    string Name,
    string PictureToken
    );
