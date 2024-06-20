namespace Domain.Common;

public class Result
{
    public Error Error { get; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public static Result Success()
    {
        return new Result(true, Error.None);
    }

    public static Result Failure(Error error)
    {
        return new Result(false, error);
    }

    private protected Result(bool isSuccess, Error error)
    {
        if(isSuccess && error != Error.None)
        {
            throw new ArgumentException(@"Successfull result cannot have an error.", nameof(error));
        }

        if(IsFailure && error == Error.None)
        {
            throw new ArgumentException(@"Failed result must have a error.", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }
}

public sealed class Result<TResult> : Result
{
    public TResult Value { get; }

    public static Result<TResult> Success(TResult result)
    {
        return new Result<TResult>(true, result, Error.None);
    }

    public static Result<TResult> Failure(Error error)
    {
        return new Result<TResult>(false, default, error);
    }

    private protected Result(bool isSuccess, TResult result, Error error) : base(isSuccess, error)
    {
        Value = result;
    }

    public static implicit operator Result<TResult>(TResult result)
    {
        return Result<TResult>.Success(result);
    }
}
