using Application.Abstractions.CQRS;
using Application.Common;

using Domain.Enum;

namespace Application.Patient.Queries;
public sealed record PatientFilterQuery(string? PartOfName, Gender? Gender, int? ExactAge, int? AgeGreaterThan, int? AgeLowerThan, Pagination Pagination) : IQuery;