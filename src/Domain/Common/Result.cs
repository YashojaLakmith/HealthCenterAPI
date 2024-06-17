namespace Domain.Common;

public class Result
{
    public Exception? Exception { get; }
    public bool IsSuccess { get; }

    public static Result Success()
    {
        return new Result(null, true);
    }

    public static Result Failure(Exception ex)
    {
        return new Result(ex, false);
    }

    protected Result(Exception? ex, bool isSuccess)
    {
        Exception = ex;
        IsSuccess = isSuccess;
    }
}
