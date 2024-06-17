namespace Domain.Common;

public sealed class Result<TResult> : Result
{
    public TResult Value { get; }

    public static Result<TResult> Success(TResult result)
    {
        return new Result<TResult>(result, null, true);
    }

    public static Result<TResult> Failure(Exception exception)
    {
        return new Result<TResult>(default, exception, false);
    }

    private Result(TResult result, Exception? ex, bool isSuccess) : base(ex, isSuccess)
    {
        Value = result;
    }

    public static implicit operator Result<TResult>(TResult value)
    {
        return new Result<TResult>(value, null, true);
    }
}
