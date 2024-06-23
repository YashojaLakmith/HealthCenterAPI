namespace Domain.Common.Errors;
public static class ChangePhoneNumberErrors
{
    private const string ErrorCodeFamily = @"ChangePhoneNumber";

    public static readonly Error PhoneNumberAlreadyInUse = new($@"{ErrorCodeFamily}.AlreadyInUse", @"Phone number is being used by another user.");
}
