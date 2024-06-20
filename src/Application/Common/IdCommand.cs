using Application.Abstractions.CQRS;

namespace Application.Common;
public sealed record IdCommand(Guid Id) : ICommand;
