using Authentication.Entities;
using Authentication.Repositories;

using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

using Infrastructure.Abstractions;

using Microsoft.EntityFrameworkCore;

namespace Repositories.RepositoryImplementations;
internal class AuthenticationServiceRepository : IAuthServiceRepository
{
    private readonly IApplicationDbContext _context;

    public AuthenticationServiceRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Credentials>> GetCredentialObjectByEmailAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        var result = await _context.Credentials
                                        .Include(credential => credential.User)
                                        .Where(credential => credential.User.EmailAddress == emailAddress)
                                        .FirstOrDefaultAsync(cancellationToken);

        if (result is null)
        {
            return Result<Credentials>.Failure(RepositoryErrors.NotFoundError);
        }

        return result;
    }

    public async Task<Result<Credentials>> GetCredentialObjectByIdAsync(Id userId, CancellationToken cancellationToken = default)
    {
        var result = await _context.Credentials
                                    .Include(cred => cred.User)
                                    .Where(cred => cred.User.Id == userId)
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
