using Authentication.Entities;
using Authentication.Repositories;

using Domain.Common;
using Domain.ValueObjects;

using Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace Repositories;
internal sealed class AuthenticationServiceRepository : IAuthServiceRepository
{
    private readonly ApplicationDbContext _context;

    public AuthenticationServiceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Credentials>> GetCredentialObjectByEmailAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        var result = await _context.Credentials
                                        .Include(credential => credential.User)
                                        .Where(credential => credential.User.EmailAddress == emailAddress)
                                        .FirstOrDefaultAsync(cancellationToken);

        if(result is null)
        {
            return Result<Credentials>.Failure(new Exception());
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
            return Result<Credentials>.Failure(new Exception());
        }

        return result;
    }

    public async Task<Result> InsertNewAsync(Credentials credentials, CancellationToken cancellationToken = default)
    {
        await _context.Credentials.AddAsync(credentials, cancellationToken);
        return Result.Success();
    }
}
