using Application.Abstractions.CQRS;
using Application.Common;

namespace Application.Doctor.Queries;
public sealed record FilterDoctorQuery(string? NamePart, Pagination Pagination) : IQuery;