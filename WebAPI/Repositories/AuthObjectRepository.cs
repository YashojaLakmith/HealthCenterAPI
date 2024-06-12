using System.Data;
using System.Data.SqlClient;

using WebAPI.Abstractions.Repositories;
using WebAPI.Abstractions.Secrets;
using WebAPI.Entities;

namespace WebAPI.Repositories;

public class AuthObjectRepository : IAuthObjectRepository
{
    private readonly IDatabaseSecrets _dbSecrets;

    public AuthObjectRepository(IDatabaseSecrets dbSecrets)
    {
        _dbSecrets = dbSecrets;
    }

    public async Task<PasswordAuthenticationObject> GetPasswordAuthenticationObjectAsync(string userId)
    {
        using var client = await CreateConnectionAsync();
        throw new NotImplementedException();
    }

    public async Task UpdateSuccessfulAuthentication(PasswordAuthenticationObject passwordAuthenticationObject)
    {
        using var client = await CreateConnectionAsync();
        throw new NotImplementedException();
    }

    private async Task<IDbConnection> CreateConnectionAsync()
    {
        var connString = await _dbSecrets.GetDbConnectionStringAsync();
        return new SqlConnection(connString);
    }
}
