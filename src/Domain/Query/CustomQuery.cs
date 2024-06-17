using System.Linq.Expressions;

using Domain.Primitives;

namespace Domain.Query;

public class CustomQuery<TEntity> where TEntity : Entity
{
    public Expression<Func<TEntity, bool>>? WherePredicate { get; }

    internal static CustomQuery<TEntity> Create(Expression<Func<TEntity, bool>>? wherePredicate)
    {
        return new CustomQuery<TEntity>(wherePredicate);
    }

    private protected CustomQuery(Expression<Func<TEntity, bool>>? wherePredicate)
    {
        WherePredicate = wherePredicate;
    }
}

public class CustomQuery<TEntity, TOut> : CustomQuery<TEntity> where TEntity : Entity
{
    public Expression<Func<TEntity, TOut>> SelectPredicate { get; }

    internal static CustomQuery<TEntity, TOut> Create(Expression<Func<TEntity, bool>>? wherePredicate, Expression<Func<TEntity, TOut>> selectPredicate)
    {
        return new CustomQuery<TEntity, TOut>(wherePredicate, selectPredicate);
    }

    private CustomQuery(Expression<Func<TEntity, bool>>? wherePredicate, Expression<Func<TEntity, TOut>> selectPredicate)
        : base(wherePredicate)
    {
        SelectPredicate = selectPredicate;
    }
}
