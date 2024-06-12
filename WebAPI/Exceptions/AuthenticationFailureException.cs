namespace WebAPI.Exceptions;

public class AuthenticationFailureException : Exception
{
    public static AuthenticationFailureException CreateOnIncorrectPassword()
    {
        return new AuthenticationFailureException(@"Password is incorrect.");
    }

    public static AuthenticationFailureException CreateOnNonExistingUser(string userId)
    {
        return new AuthenticationFailureException($@"There is no user with the ID {userId}.");
    }

    private AuthenticationFailureException(string message) : base(message) { }
}
