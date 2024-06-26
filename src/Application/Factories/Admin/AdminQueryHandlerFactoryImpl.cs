using Application.Abstractions.CQRS;
using Application.Abstractions.Factories.Admin;
using Application.Abstractions.ReadOnlyRepositories;
using Application.Admin.Queries;
using Application.Admin.QueryHandlers;
using Application.Admin.Views;
using Application.Common;

namespace Application.Factories.Admin;

internal sealed class AdminQueryHandlerFactoryImpl : IAdminQueryHandlerFactory
{
    private readonly IReadOnlyAdminRepository _adminRepository;

    private IQueryHandler<IReadOnlyCollection<AdminListItem>, AdminFilterQuery>? _listViewHandler;
    private IQueryHandler<AdminDetailView, IdQuery>? _detailViewHandler;

    public AdminQueryHandlerFactoryImpl(IReadOnlyAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public IQueryHandler<IReadOnlyCollection<AdminListItem>, AdminFilterQuery> AdminListViewQueryHandler
        => _listViewHandler ??= new AdminListQueryHandler(_adminRepository);

    public IQueryHandler<AdminDetailView, IdQuery> AdminDetailViewQueryHandler
        => _detailViewHandler ??= new AdminDetailViewQueryHandler(_adminRepository);
}