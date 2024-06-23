using Application.Abstractions.CQRS;

namespace Application.Session.Commands;
public sealed record DeleteSessionCommand(Guid DoctorId, Guid SessionId) : ICommand;
