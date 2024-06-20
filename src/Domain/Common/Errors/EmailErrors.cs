namespace Domain.Common.Errors;
public static class EmailErrors
{
    private const string ErrorCodeFamily = @"EmailEror";

    public static readonly Error EmailAlreadyExists = new($@"{ErrorCodeFamily}.Duplicate", @"User with the given email address already exists.");

    public static readonly Error InvalidEmailAddress = new($@"{ErrorCodeFamily}.Validation.Invalid", @"Given value is not a valid email address.");

    public static readonly Error EmptyEmailAddress = new($@"{ErrorCodeFamily}.Validation.EmptyEmail", @"Provided email address is empty.");
}
