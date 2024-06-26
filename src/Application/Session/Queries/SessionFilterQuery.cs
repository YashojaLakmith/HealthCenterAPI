using Application.Abstractions.CQRS;
using Application.Common;

namespace Application.Session.Queries;
public sealed record SessionFilterQuery(string? DoctorName, DateTimeRange? DateTimeRange, Pagination Pagination) : IQuery;