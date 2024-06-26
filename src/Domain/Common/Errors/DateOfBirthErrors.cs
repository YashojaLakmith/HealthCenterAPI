namespace Domain.Common.Errors;
public static class DateOfBirthErrors
{
    private const string ErrorCodeFamily = @"Validation.DateOfBith";

    public static readonly Error AgeIsLowerThan16Years = new($@"{ErrorCodeFamily}", @"Age cannot be less than 16 years.");

    public static readonly Error AgeIsZeroOrNegative = new($@"{ErrorCodeFamily}.ZeroOrNegativeAge", @"Age cannot be zero or negative.");
}
