using Application.Abstractions.CQRS;
using Application.Admin.Queries;
using Application.Admin.Views;
using Application.Common;
using Domain.Common;

namespace Application.Abstractions.Factories.Admin;

public interface IAdminQueryHandlerFactory
{
    IQueryHandler<IReadOnlyCollection<AdminListItem>, AdminFilterQuery> AdminListViewQueryHandler { get; }
    IQueryHandler<AdminDetailView, IdQuery> AdminDetailViewQueryHandler { get; }
}