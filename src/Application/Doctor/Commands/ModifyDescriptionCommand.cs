using Application.Abstractions.CQRS;

namespace Application.Doctor.Commands;
public sealed record ModifyDescriptionCommand(Guid DoctorId, string NewDescription) : ICommand;