using Domain.Common;

namespace Application.Abstractions.CQRS;
public interface IQueryHandler<TResult>
{
    Task<Result<TResult>> HandleAsync(CancellationToken cancellationToken = default);
}

public interface IQueryHandler<TResult, TQuery> where TQuery : IQuery
{
    Task<Result<TResult>> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}