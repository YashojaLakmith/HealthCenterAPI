namespace Domain.Common.Errors;
public static class IdErrors
{
    private const string ErrorCodeFamily = @"Validation.Id";

    public static readonly Error InvalidId = new($@"{ErrorCodeFamily}.Invalid", @"Id is not in valid format.");
}
