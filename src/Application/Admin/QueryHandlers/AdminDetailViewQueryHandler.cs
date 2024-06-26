using Application.Abstractions.CQRS;
using Application.Abstractions.ReadOnlyRepositories;
using Application.Common;
using Application.Admin.Views;

using Domain.Common;
using Domain.ValueObjects;

namespace Application.Admin.QueryHandlers;
internal class AdminDetailViewQueryHandler : IQueryHandler<AdminDetailView, IdQuery>
{
    private readonly IReadOnlyAdminRepository _adminRepository;

    public AdminDetailViewQueryHandler(IReadOnlyAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<Result<AdminDetailView>> HandleAsync(IdQuery query, CancellationToken cancellationToken = default)
    {
        var idResult = Id.CreateId(query.Id);
        if (idResult.IsFailure)
        {
            return Result<AdminDetailView>.Failure(idResult.Error);
        }

        return await _adminRepository.GetAdminDetailViewAsync(idResult.Value, cancellationToken);
    }
}
