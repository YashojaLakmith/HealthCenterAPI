namespace Domain.Common;
public sealed record Error(string ErrorCode, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public static implicit operator Result(Error error)
    {
        return error == Error.None ? Result.Success() : Result.Failure(error);
    }
}