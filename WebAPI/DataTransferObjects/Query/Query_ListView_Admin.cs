namespace WebAPI.DataTransferObjects.Query;

public record Query_ListView_Admin(
    string SenderType,
    string Sender,
    DateTime SentOn,
    string Subject,
    string QueryStatus
    );
