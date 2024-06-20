namespace Domain.Common.Errors;
public static class NameErrors
{
    private const string ErrorCodeFamily = @"Validation.Name";

    public static readonly Error ExceedsMaximumCharacters = new($@"{ErrorCodeFamily}.ExceedsCharacteLimit", @"Maximum character limit is 100");

    public static readonly Error LessThanMinimumCharacters = new($@"{ErrorCodeFamily}.LessThanMinimumLength", @"Minimum character limit is 3");

    public static readonly Error EmptyName = new($@"{ErrorCodeFamily}.Empty", @"Name is empty");
}
