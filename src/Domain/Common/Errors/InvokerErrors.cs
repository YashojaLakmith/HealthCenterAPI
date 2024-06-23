namespace Domain.Common.Errors;

public static class InvokerErrors
{
    private const string ErrorCodeFamily = @"Invoker";

    public static readonly Error InvokerNotFound = new($@"{ErrorCodeFamily}.NotFound", @"Invoking user not found.");
}