namespace Services.DataTransferObjects.Query;

public record Query_ListView_Sender(
    string QueryId,
    DateTime SentOn,
    string Subject,
    string QueryStatus
    );
