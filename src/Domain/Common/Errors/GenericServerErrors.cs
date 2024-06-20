namespace Domain.Common.Errors;
public static class GenericServerErrors
{
    private const string ErrorCodeFamily = @"Server.Generic";

    public static readonly Error ServerError = new(ErrorCodeFamily, @"An error was occured while processing the request");
}
