using Application.Abstractions.CQRS;

namespace Application.Common;
public sealed record IdCommandQuery(Guid Id) : ICommand, IQuery;
