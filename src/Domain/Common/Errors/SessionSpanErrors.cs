namespace Domain.Common.Errors;
public static class SessionSpanErrors
{
    private const string ErrorCodeFamily = @"Validation.SessionSpan";

    public static readonly Error Invalid = new($@"{ErrorCodeFamily}.Invalid", @"Session start time is later than end time.");

    public static readonly Error ExceedMaxDuration = new($@"{ErrorCodeFamily}.ExceedsMaxDuration", @"Session duration must not exceed 6 hours.");

    public static readonly Error LessThanMinDuration = new Error($@"{ErrorCodeFamily}.LessThanMinDuration", @"Session duration must be greater than 30 minutes.");
}
