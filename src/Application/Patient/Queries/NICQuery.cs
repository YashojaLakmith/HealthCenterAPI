using Application.Abstractions.CQRS;

namespace Application.Patient.Queries;
public sealed record NICQuery(string NICNumber) : IQuery;