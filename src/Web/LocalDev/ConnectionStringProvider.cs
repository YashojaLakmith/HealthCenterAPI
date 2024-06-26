using Infrastructure.Abstractions;

namespace Web.LocalDev;

public sealed class ConnectionStringProvider : IDbConnectionStringSource
{
    public Task<string> GetConnectionStringAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(GetConnectionString());
    }

    public string GetConnectionString()
    {
        return """
               Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=E:\Program Data\SQL Server LocalDB\health-api.mdf

               """;
    }
}