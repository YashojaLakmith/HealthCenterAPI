using System.Data;

using Authentication.Entities;
using Authentication.Repositories;

using Dapper;

using Domain.Common;
using Domain.ValueObjects;

using Repositories.StoredProcedureBuilders;

namespace Repositories;
internal sealed class AuthenticationServiceRepository : BaseSqlService, IAuthServiceRepository
{
    public async Task<Result<Credentials>> GetCredentialObjectAsync(Id userId, CancellationToken cancellationToken)
    {
        var proc = StoredProcedures.GetCredentialById(userId.Value);
        using var conn = await CreateConnectionAsync();
        var results = await conn.QueryFirstOrDefaultAsync<Credentials>(proc.ProcedureName, proc.Parameters, commandType: CommandType.StoredProcedure);
        
        if(results is null)
        {
            return Result<Credentials>.Failure(new Exception());
        }

        return results;
    }

    public async Task<Result> InsertNewAsync(Credentials credentials, CancellationToken cancellationToken = default)
    {
        var proc = StoredProcedures.InsertCredentials(credentials);
        var conn = await CreateConnectionAsync();
        try
        {
            await conn.ExecuteAsync(proc.ProcedureName, proc.Parameters, commandType: CommandType.StoredProcedure);
            return Result.Success();
        }
        catch(Exception e)
        {
            return Result.Failure(e);
        }
    }

    public async Task<Result> SaveChangesAsync(Credentials credentials, CancellationToken cancellationToken)
    {
        var proc = StoredProcedures.UpdateCredentials(credentials);
        using var conn = await CreateConnectionAsync();
        try
        {
            await conn.ExecuteAsync(proc.ProcedureName, proc.Parameters, commandType: CommandType.StoredProcedure);
            return Result.Success();
        }
        catch(Exception e)
        {
            return Result.Failure(e);
        }        
    }

    private static void SetValue<TObject, TProperty>(TObject obj, string propertyName, TProperty value)
    {
        obj.GetType().GetProperty(propertyName)
            .SetValue(obj, value);
    }
}
