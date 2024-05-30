namespace Services.DataTransferObjects.LoginAndPasswords;

public record TokenBasedPasswordResetData(
    string NewPassword,
    string NewPasswordConfirmation
    );
