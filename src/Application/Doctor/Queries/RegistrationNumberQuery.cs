using Application.Abstractions.CQRS;

namespace Application.Doctor.Queries;
public sealed record RegistrationNumberQuery(string RegistrationNumber) : IQuery;