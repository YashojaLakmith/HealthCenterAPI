namespace Application.Session.Views;
public sealed record SessionDetailView(Guid SessionId, Guid DoctorId, string DoctorName, DateTime SessionStartTime, DateTime SessionEndTime);