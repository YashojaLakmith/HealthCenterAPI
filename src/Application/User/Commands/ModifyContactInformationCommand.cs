using Application.Abstractions.CQRS;

namespace Application.User.Commands;
public sealed record ModifyContactInformationCommand(Guid UserId, string? NewEmail, string? NewPhoneNumber) : ICommand;
