namespace Domain.Common.Errors;
public static class DescriptionErrors
{
    private const string ErrorCodeFamily = @"Validation.Description";

    public static readonly Error DescriptionIsEmpty = new($@"{ErrorCodeFamily}.Empty", @"Description string is empty.");

    public static readonly Error ExceedsCharacterLength = new($@"{ErrorCodeFamily}.Length", @"Description character length cannot exceed 500 characters.");
}
