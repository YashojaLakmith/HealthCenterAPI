using Authentication.Entities;

using Dapper;

namespace Repositories.StoredProcedureBuilders;
internal static class StoredProcedures
{
    public static StoredProcedureParameters GetCredentialById(Guid id)
    {
        const string name = @"GetCredentialsById";
        var parameters = new DynamicParameters();
        parameters.Add(@"Id", id);

        return new StoredProcedureParameters(name, parameters);
    }

    public static StoredProcedureParameters InsertCredentials(Credentials credentials)
    {
        const string name = @"InsertNewCredentials";
        var parameters = new DynamicParameters();
        parameters.Add(@"Id", credentials.Id.Value);
        parameters.Add(@"PwHash", credentials.PasswordHash);
        parameters.Add(@"PwSalt", credentials.Salt);
        parameters.Add(@"TimeStamp", credentials.CurrentTimeStamp);

        return new StoredProcedureParameters(name, parameters);
    }

    public static StoredProcedureParameters UpdateCredentials(Credentials credentials)
    {
        const string name = @"UpdateCredentials";
        var parameters = new DynamicParameters();
        parameters.Add(@"Id", credentials.Id.Value);
        parameters.Add(@"PwHash", credentials.PasswordHash);
        parameters.Add(@"PwSalt", credentials.Salt);
        parameters.Add(@"TimeStamp", credentials.CurrentTimeStamp);

        return new StoredProcedureParameters(name, parameters);
    }
}
