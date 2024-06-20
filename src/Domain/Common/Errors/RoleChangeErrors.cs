namespace Domain.Common.Errors;
public static class RoleChangeErrors
{
    private const string ErrorCodeFamily = @"RoleChange";

    public static readonly Error NotHaveAuthorization = new($@"{ErrorCodeFamily}.Unauthorized", @"Admin does not have power to change role of the give admin.");
}
