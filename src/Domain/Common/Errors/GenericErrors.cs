namespace Domain.Common.Errors;
public static class GenericErrors
{
    public static readonly Error ServerError = new(@"GenericServerError", @"An error was occured while processing the request");
}
