using Application.Abstractions.CQRS;
using Application.Abstractions.Factories.Session;
using Application.Abstractions.ReadOnlyRepositories;
using Application.Common;
using Application.Session.Queries;
using Application.Session.QueryHandlers;
using Application.Session.Views;

namespace Application.Factories.Session;

internal sealed class SessionQueryHandlerFactoryImpl : ISessionQueryHandlerFactory
{
    private readonly IReadOnlySessionRepository _sessionRepository;

    private IQueryHandler<IReadOnlyCollection<SessionListItemView>, SessionFilterByDoctorIdQuery>? _listViewByDoctorId;
    private IQueryHandler<IReadOnlyCollection<SessionListItemView>, SessionFilterQuery>? _listViewGeneric;
    private IQueryHandler<SessionDetailView, IdQuery>? _detailView;
    

    public SessionQueryHandlerFactoryImpl(IReadOnlySessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public IQueryHandler<IReadOnlyCollection<SessionListItemView>, SessionFilterByDoctorIdQuery>
        SessionListViewByDoctorIdQueryHandler
            => _listViewByDoctorId ??= new ViewSessionListByDoctorQueryHandler(_sessionRepository);

    public IQueryHandler<IReadOnlyCollection<SessionListItemView>, SessionFilterQuery> SessionListViewQueryHandler
        => _listViewGeneric ??= new ViewSessionListQueryHandler(_sessionRepository);

    public IQueryHandler<SessionDetailView, IdQuery> SessionDetailViewQueryHandler
        => _detailView ??= new ViewSessionDetailsQueryHandler(_sessionRepository);
}