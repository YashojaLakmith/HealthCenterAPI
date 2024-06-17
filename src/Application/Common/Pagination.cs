using Application.Abstractions.CQRS;

namespace Application.Common;
public sealed record Pagination(int PageNumber, int ResultsPerPage) : IQuery;
