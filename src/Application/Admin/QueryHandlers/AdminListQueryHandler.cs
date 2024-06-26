using Application.Abstractions.CQRS;
using Application.Abstractions.ReadOnlyRepositories;
using Application.Admin.Queries;
using Application.Admin.Views;
using Application.CustomFilters;
using Domain.Common;
using Domain.ValueObjects;

namespace Application.Admin.QueryHandlers;
internal class AdminListQueryHandler : IQueryHandler<IReadOnlyCollection<AdminListItem>, AdminFilterQuery>
{
    private readonly IReadOnlyAdminRepository _adminRepository;

    public AdminListQueryHandler(IReadOnlyAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<Result<IReadOnlyCollection<AdminListItem>>> HandleAsync(AdminFilterQuery query, CancellationToken cancellationToken = default)
    {
        var paginationResult = Pagination.Create(query.Pagination.ResultsPerPage, query.Pagination.PageNumber);
        if (paginationResult.IsFailure)
        {
            return Result<IReadOnlyCollection<AdminListItem>>.Failure(paginationResult.Error);
        }

        var filter = AdminFilter.CreateFilter(paginationResult.Value, query.AdminName, query.Role);
        return await _adminRepository.GetAdminListAsync(filter, cancellationToken);
    }
}
