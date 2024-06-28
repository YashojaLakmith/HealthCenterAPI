using Application.Abstractions.CQRS;

namespace Application.Session.Commands;
public sealed record ModifySessionTimeCommand(Guid SessionId, DateTime? SessionStartTime, DateTime? SessionEndTime) : ICommand;