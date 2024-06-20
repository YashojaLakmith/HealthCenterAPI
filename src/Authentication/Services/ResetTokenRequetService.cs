using Authentication.Repositories;
using Authentication.ValueObjects;

using Domain.Common;
using Domain.Entities;

namespace Authentication.Services;
public class ResetTokenRequetService
{
    private readonly IResetTokenStore _resetTokenStore;

    public ResetTokenRequetService(IResetTokenStore resetTokenStore)
    {
        _resetTokenStore = resetTokenStore;
    }

    public Task<Result<ResetToken>> RequestResetTokenAsync(Admin admin, CancellationToken cancellationToken = default)
    {
        var tokenResult = ResetToken.CreateToken();
    }
}
