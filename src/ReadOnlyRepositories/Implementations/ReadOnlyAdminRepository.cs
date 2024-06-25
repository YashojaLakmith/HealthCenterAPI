using Application.Abstractions.ReadOnlyRepositories;
using Application.Admin.Queries;
using Application.Admin.Views;
using Application.CustomFilters;
using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using ReadOnlyRepositories.Evaluators;
using ReadOnlyRepositories.Extensions;

namespace ReadOnlyRepositories.Implementations;

internal sealed class ReadOnlyAdminRepository : IReadOnlyAdminRepository
{
    private readonly IApplicationDbContext _dbContext;

    public ReadOnlyAdminRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<UserDetailView>> GetAdminDetailViewAsync(Id adminId, CancellationToken cancellationToken = default)
    {
        var queryResult = await _dbContext.Admins
            .AsNoTracking()
            .Where(admin => admin.Id == adminId)
            .Select(admin => admin.AsDetailView())
            .FirstOrDefaultAsync(cancellationToken);

        return queryResult ?? Result<UserDetailView>.Failure(RepositoryErrors.NotFoundError);
    }

    public async Task<Result<IReadOnlyCollection<UserListItem>>> GetUserListAsync(AdminFilter filter, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Admins
            .AsNoTracking()
            .EvaluateFilter(filter)
            .Select(admin => admin.AsListItem())
            .ToListAsync(cancellationToken);
    }
}