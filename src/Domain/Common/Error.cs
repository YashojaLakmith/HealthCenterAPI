namespace Domain.Common;
public sealed record Error(string ErrorCode, string? Description = null)
{
    public static readonly Error Empty = new(string.Empty, null);
}