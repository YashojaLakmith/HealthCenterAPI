using Domain.Common;

namespace Domain.Repositories;
public static class RepositoryErrors
{
    private const string ErrorCodeFamily = @"Persistence";

    public static readonly Error ConcurrencyError = new($@"{ErrorCodeFamily}.Concurrency", @"The record has been modified after it has been retrieved for current operation.");

    public static readonly Error IOError = new Error($@"{ErrorCodeFamily}.IO", @"Could not fetch the data");

    public static readonly Error NotFoundError = new Error($@"{ErrorCodeFamily}.NotFound", @"Could not find the reuqested data.");
}
