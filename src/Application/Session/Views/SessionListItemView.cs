namespace Application.Session.Views;
public sealed record SessionListItemView(Guid SessionId, DateTime SessionStartTime, DateTime SessionEndTime);