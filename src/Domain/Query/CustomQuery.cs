using System.Linq.Expressions;

using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Query;

public class CustomQuery<TEntity, TOut> where TEntity : Entity
{
    public Expression<Func<TEntity, bool>>? WherePredicate { get; }
    public Pagination? PaginationPredicate { get; }
    public Expression<Func<TEntity, TOut>> SelectPredicate { get; }

    internal static CustomQuery<TEntity, TOut> Create(Expression<Func<TEntity, bool>>? wherePredicate, Pagination? paginationPredicate, Expression<Func<TEntity, TOut>> selectPredicate)
    {
        return new CustomQuery<TEntity, TOut>(wherePredicate, paginationPredicate, selectPredicate);
    }

    private CustomQuery(Expression<Func<TEntity, bool>>? wherePredicate, Pagination? paginationPredicate, Expression<Func<TEntity, TOut>> selectPredicate)
    {
        WherePredicate = wherePredicate;
        PaginationPredicate = paginationPredicate;
        SelectPredicate = selectPredicate;
    }
}
