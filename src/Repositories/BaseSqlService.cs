using Microsoft.Data.SqlClient;

namespace Repositories;
internal abstract class BaseSqlService
{
    private readonly string _connectionString = @"@""Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Db_HealthCenterAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False""";
    protected Task<SqlConnection> CreateConnectionAsync()
    {
        return Task.FromResult(new SqlConnection(_connectionString));
    }
}
