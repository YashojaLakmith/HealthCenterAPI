namespace Domain.Error;
public class Error
{
    public string Message { get; }
    public string Handler { get; }

    public static Error CreateError(string message, string handler)
    {
        return new Error(message, handler);
    }

    private Error(string message, string handler)
    {
        Message = message;
        Handler = handler;
    }
}
