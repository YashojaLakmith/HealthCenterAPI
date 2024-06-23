namespace Domain.Common.Errors;
public static class DoctorErrors
{
    private const string ErrorCodeFamily = @"Application.Doctor";

    public static readonly Error NotFound = new($@"{ErrorCodeFamily}.NotExists", @"Searched doctor not found.");
}
