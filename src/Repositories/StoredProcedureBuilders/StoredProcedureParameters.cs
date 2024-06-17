using Dapper;

namespace Repositories.StoredProcedureBuilders;
internal readonly struct StoredProcedureParameters
{
    public readonly string ProcedureName;
    public readonly DynamicParameters Parameters;

    public StoredProcedureParameters(string procedureName, DynamicParameters parameters)
    {
        ProcedureName = procedureName;
        Parameters = parameters;
    }
}
