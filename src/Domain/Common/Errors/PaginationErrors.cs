namespace Domain.Common.Errors;
public static class PaginationErrors
{
    private const string ErrorCodeFamily = @"Validation.Pagination";

    public static readonly Error NegativeValues = new($@"{ErrorCodeFamily}.Negative", @"Values cannot be negative.");

    public static readonly Error ResultsPerPageIsZero = new($@"{ErrorCodeFamily}.ResultCountIsZero", @"Results per page count cannot be zero.");

    public static readonly Error ResultsPerPageCountLimitExceeded = new($@"{ErrorCodeFamily}.ResultsPerPageLimitExceeded", $@"Results per page count cannot exceed 100 records.");
}
