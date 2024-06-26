using Domain.Common;

namespace Authentication.Errors;

public static class TokenErrors
{
    private const string ErrorCodeFamily = @"Token";
    
    public static readonly Error InvalidToken = new Error($@"{ErrorCodeFamily}.Invalid", @"Token is invalid or corrupted.");
}