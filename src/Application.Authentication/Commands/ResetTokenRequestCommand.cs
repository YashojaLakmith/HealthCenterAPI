using Application.Authentication.Abstractions.CQRS;

namespace Application.Authentication.Commands;
public sealed record ResetTokenRequestCommand(string EmailAddress) : ICommand;