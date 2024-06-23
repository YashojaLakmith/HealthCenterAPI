using Application.Abstractions.CQRS;
using Application.Session.Commands;

namespace Application.Abstractions.Factories.Session;

public interface ISessionCommandHandlerFactory
{
    ICommandHandler<CreateSessionCommand> CreateSessionCommandHandler { get; }
    ICommandHandler<DeleteSessionCommand> DeleteSessionCommandHandler { get; }
    ICommandHandler<ModifySessionTimeCommand> ModifySessionTimeCommandHandler { get; }
}