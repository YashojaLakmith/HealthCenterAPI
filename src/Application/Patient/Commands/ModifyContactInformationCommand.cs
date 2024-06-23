using Application.Abstractions.CQRS;

namespace Application.Patient.Commands;
public sealed record ModifyContactInformationCommand(Guid PatientId, string? PhoneNumber, string? EmailAddress) : ICommand;