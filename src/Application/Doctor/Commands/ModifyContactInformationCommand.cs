using Application.Abstractions.CQRS;

namespace Application.Doctor.Commands;
public sealed record ModifyContactInformationCommand(Guid DoctorId, string PhoneNumber, string EmailAddress) : ICommand;