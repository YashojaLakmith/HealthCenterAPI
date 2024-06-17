using Application.Abstractions.CQRS;

namespace Application.Session.Commands;
public record CreateSessionCommand(Guid DoctorId, string Room, DateTime SessionStart, DateTime SessionEnd) : ICommand;
