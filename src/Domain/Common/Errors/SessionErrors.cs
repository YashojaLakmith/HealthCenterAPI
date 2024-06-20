namespace Domain.Common.Errors;
public static class SessionErrors
{
    private const string ErrorCodeFamily = @"Sessions";

    public static readonly Error SessionNotFound = new($@"{ErrorCodeFamily}.NotFound", @"Session not found.");

    public static readonly Error RemovingAnAlreadyStatedSession = new($@"{ErrorCodeFamily}.SessionInProgress", @"Cannot remove a session that have already started.");

    public static readonly Error HasOverlappingSessions = new($@"{ErrorCodeFamily}.Overlapping", @"New session's time period overlaps with an existing session.");

    public static readonly Error ModifyingAnAlreadyStatedSessionTime = new($@"{ErrorCodeFamily}.SessionInProgress", @"Cannot modify a session's time that has already started.");
}
