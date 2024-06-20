namespace Domain.Common.Errors;
public static class NICErrors
{
    private const string ErrorCodeFamily = @"Validation.NIC";

    public static readonly Error InvalidLength = new($@"{ErrorCodeFamily}.InvalidLength", @"NIC length must be 9 or 12 characters.");

    public static readonly Error InvalidCharacterIn12DigitNIC = new($@"{ErrorCodeFamily}.InvalidCharacter", @"12 digit NIC cannot have letters.");

    public static readonly Error InvalidCharacterIn9DigitNIC = new($@"{ErrorCodeFamily}.InvalidCharacter", "9 digit NIC can only have X or V as the last digit.");

    public static readonly Error EmptyNIC = new($@"{ErrorCodeFamily}.Empty", @"NIC is empty");
}
