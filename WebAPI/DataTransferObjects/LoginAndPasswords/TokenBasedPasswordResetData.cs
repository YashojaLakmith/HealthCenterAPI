namespace WebAPI.DataTransferObjects.LoginAndPasswords;

public record TokenBasedPasswordResetData(
    string NewPassword,
    string NewPasswordConfirmation
    );
