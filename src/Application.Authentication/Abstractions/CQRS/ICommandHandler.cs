using Domain.Common;

namespace Application.Authentication.Abstractions.CQRS;
public interface ICommandHandler
{
    Task<Result> HandleAsync(CancellationToken cancellationToken = default);
}

public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    Task<Result> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<TResult, TCommand> where TCommand : ICommand
{
    Task<Result<TResult>> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}