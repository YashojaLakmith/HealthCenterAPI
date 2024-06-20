namespace Domain.Common.Errors;
public static class RegistrationNumberErrors
{
    private const string ErrorCodeFamily = @"RegistrationNumber";

    public static readonly Error RegistrationNumberAlreadyExists = new($@"{ErrorCodeFamily}.Duplicate", @"A doctor with the given registration number already exists.");
}
