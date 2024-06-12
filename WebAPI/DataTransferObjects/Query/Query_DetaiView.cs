namespace WebAPI.DataTransferObjects.Query;

public record Query_DetaiView(
    string QueryId,
    string SenderType,
    string SenderId,
    string Subject,
    string Content,
    DateTime SentOn,
    string QueryStatus
    );
