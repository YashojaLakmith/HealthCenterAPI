using Application.Abstractions.CQRS;
using Application.Common;
using Application.Session.Queries;
using Application.Session.Views;
using Domain.Common;

namespace Application.Abstractions.Factories.Session;

public interface ISessionQueryHandlerFactory
{
    IQueryHandler<IReadOnlyCollection<SessionListItemView>, SessionFilterByDoctorIdQuery> SessionListViewByDoctorIdQueryHandler
    {
        get;
    }
    IQueryHandler<IReadOnlyCollection<SessionListItemView>, SessionFilterQuery> SessionListViewQueryHandler
    {
        get;
    }
    IQueryHandler<SessionDetailView, IdQuery> SessionDetailViewQueryHandler { get; }
}