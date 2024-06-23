namespace Domain.Common.Errors;
public static class PhoneNumberErrors
{
    private const string ErrorCodeFamily = @"Validation.PhoneNumber";

    public static readonly Error InvalidLength = new($@"{ErrorCodeFamily}.InvalidLength", @"Phone number length must be 10 digits.");

    public static readonly Error InvalidCharacters = new($@"{ErrorCodeFamily}.InvalidCharacters", @"Phone number can only contain numbers.");

    public static readonly Error EmptyPhoneNumber = new($@"{ErrorCodeFamily}.Empty", @"Phone number is empty.");
}
