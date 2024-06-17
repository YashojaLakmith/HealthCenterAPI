using Application.Abstractions.CQRS;

namespace Application.Authentication.Commands;
public sealed record LoginCommand(string EmailAddress, string Password) : ICommand;
