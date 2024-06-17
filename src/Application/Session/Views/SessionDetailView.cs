namespace Application.Session.Views;
public sealed record SessionDetailView(Guid SessionId, Guid DoctorId, Guid DoctorName, string Room, DateTime SessionStartTime, DateTime SessionEndTime);