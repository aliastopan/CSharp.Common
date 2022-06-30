namespace Common.Wrappers;

public class Result
{
    public bool IsSuccess { get; init; }
    public bool IsFailure => !IsSuccess;
    public Exception? Exception { get; init; }
    public string Verdict
    {
        get => Exception is null
            ? "OK."
            : Exception.Message;
    }

    protected Result(bool isSuccess, Exception exception)
    {
        if(!isSuccess && exception is null) throw new InvalidOperationException();

        this.IsSuccess = isSuccess;
        this.Exception = exception;
    }

    public static Result Fail(Exception exception)
    {
        return new Result(false, exception);
    }

    public static Result<TValue> Fail<TValue>(Exception exception)
    {
        return new Result<TValue>(default!, false, exception);
    }

    public static Result Ok()
    {
        return new Result(true, null!);
    }

    public static Result<TValue> Ok<TValue>(TValue value)
    {
        return new Result<TValue>(value, true, null!);
    }
}

public class Result<TValue> : Result
{
    protected internal Result(TValue value, bool isSuccess, Exception exception)
        : base(isSuccess, exception)
    {
        this.Value = value;
    }

    public TValue Value { get; init; }
}