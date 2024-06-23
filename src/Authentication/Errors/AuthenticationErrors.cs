using Domain.Common;

namespace Authentication.Errors;
public static class AuthenticationErrors
{
    private const string ErrorCodeFamily = @"Authentication";

    public static readonly Error PasswordAuthenticationFailedError = new($@"{ErrorCodeFamily}.PasswordAuthentication", @"Unable to authenticate with the password.");
}
