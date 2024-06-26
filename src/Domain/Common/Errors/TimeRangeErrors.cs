namespace Domain.Common.Errors;

public static class TimeRangeErrors
{
    private const string ErrorCodeFamily = @"TimeRangeError";

    public static readonly Error InvalidTimeRange = new($@"{ErrorCodeFamily}.Invalid", @"Time range is invalid.");
}