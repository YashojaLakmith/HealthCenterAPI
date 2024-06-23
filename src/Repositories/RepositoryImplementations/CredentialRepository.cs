using Authentication.Entities;
using Authentication.Repositories;

using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

using Infrastructure.Abstractions;

using Microsoft.EntityFrameworkCore;

namespace Repositories.RepositoryImplementations;
internal sealed class CredentialRepository : ICredentialRepository
{
    private readonly IApplicationDbContext _context;

    public CredentialRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Credentials>> GetCredentialObjectByEmailAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        var result = await _context.Credentials
                                        .Include(credential => credential.Admin)
                                        .Where(credential => credential.Admin.EmailAddress == emailAddress)
                                        .FirstOrDefaultAsync(cancellationToken);

        return result ?? Result<Credentials>.Failure(RepositoryErrors.NotFoundError);
    }

    public async Task<Result<Credentials>> GetCredentialObjectByIdAsync(Id userId, CancellationToken cancellationToken = default)
    {
        var result = await _context.Credentials
                                    .Include(cred => cred.Admin)
                                    .Where(cred => cred.Admin.Id == userId)
                                    .FirstOrDefaultAsync(cancellationToken);

        if (result is null)
        {
            return Result<Credentials>.Failure(RepositoryErrors.NotFoundError);
        }

        return result;
    }

    public async Task<Result> InsertNewAsync(Credentials credentials, CancellationToken cancellationToken = default)
    {
        await _context.Credentials.AddAsync(credentials, cancellationToken);
        return Result.Success();
    }
}
