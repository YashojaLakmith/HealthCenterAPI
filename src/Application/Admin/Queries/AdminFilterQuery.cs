using Application.Abstractions.CQRS;
using Application.Common;
using Domain.Enum;

namespace Application.Admin.Queries;
public sealed record AdminFilterQuery(string? AdminName, Role? Role, Pagination Pagination) : IQuery;