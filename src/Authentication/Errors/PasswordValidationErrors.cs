using Authentication.ValueObjects;

using Domain.Common;

namespace Authentication.Errors;
public static class PasswordValidationErrors
{
    private const string ErrorCodeFamily = @"PasswordValidation";

    public static readonly Error MinimumPasswordLengthError = new($@"{ErrorCodeFamily}.MinimumPasswordLength", $@"Minimum password length must be {Password.MinPasswordLength} characters");

    public static readonly Error MaximumPasswordLengthError = new($@"{ErrorCodeFamily}.MaximumPasswordLength", $@"Maximum password length must be {Password.MaxPasswordLength} characters");

    public static readonly Error InvalidPasswordCharacterError = new($@"{ErrorCodeFamily}.InvalidCharacter", $@"There is an invalid character in the password.");
}
