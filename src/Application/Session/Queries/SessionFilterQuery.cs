using Application.Abstractions.CQRS;
using Application.Common;

namespace Application.Session.Queries;
public sealed record SessionFilterQuery(Guid? DoctorId, DateTimeRange? DateTimeRange, Pagination Pagination) : IQuery;