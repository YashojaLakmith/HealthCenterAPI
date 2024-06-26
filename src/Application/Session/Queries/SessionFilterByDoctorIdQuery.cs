using Application.Abstractions.CQRS;
using Application.Common;

namespace Application.Session.Queries;

public sealed record SessionFilterByDoctorIdQuery(Guid? DoctorId, DateTimeRange? TimeRange, Pagination Pagination) : IQuery;