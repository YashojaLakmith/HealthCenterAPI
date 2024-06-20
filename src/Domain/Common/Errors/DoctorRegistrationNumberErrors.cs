namespace Domain.Common.Errors;
public static class DoctorRegistrationNumberErrors
{
    private const string ErrorCodeFamily = @"Validation.RegistrationNumber";

    public static readonly Error EmptyString = new($@"{ErrorCodeFamily}.Empty", @"Registration number is empty.");

    public static readonly Error InvalidLength = new($@"{ErrorCodeFamily}.InvalidLength", @"Registration number must have 10 characters");

    public static readonly Error InvalidCharacters = new($@"{ErrorCodeFamily}.InvalidCharacters", @"Registration number should only contain numbers.");
}
