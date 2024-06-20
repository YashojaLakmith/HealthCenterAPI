using Application.Abstractions.CQRS;

namespace Application.Common;
public sealed record IdQuery(Guid Id) : IQuery;
