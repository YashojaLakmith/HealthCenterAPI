namespace Services.DataTransferObjects.LoginAndPasswords;

public record ChangePasswordInformation(
    string UserId,
    string CurrentPassword,
    string NewPassword,
    string NewPasswordConfirmation
    );
