using Application.Session.Views;
using Domain.Entities;

namespace ReadOnlyRepositories.Extensions;

internal static class SessionExtensions
{
    internal static SessionDetailView AsDetailView(this Session session)
    {
        return new SessionDetailView(
            session.Id.Value,
            session.Doctor.Id.Value,
            session.Doctor.DoctorName.Value,
            session.SessionSpan.SessionStartValue,
            session.SessionSpan.SessionEndValue);
    }

    internal static SessionListItemView AsListItem(this Session session)
    {
        return new SessionListItemView(
            session.Id.Value,
            session.SessionSpan.SessionStartValue,
            session.SessionSpan.SessionEndValue);
    }
}