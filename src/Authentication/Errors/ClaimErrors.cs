using Domain.Common;

namespace Authentication.Errors;
public static class ClaimErrors
{
    private const string ErrorCodeFamily = @"ClaimError";

    public static readonly Error CouldNotProvideIdentity = new($@"{ErrorCodeFamily}.Identity", @"Could not find the identifier.");
}
