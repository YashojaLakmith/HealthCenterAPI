using Application.Abstractions.CQRS;
using Application.Common;

namespace Application.User.Queries;
public sealed record UserFilterQuery(string? UserName, Pagination Pagination) : IQuery;