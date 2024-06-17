using Application.Abstractions.CQRS;

using Domain.Enum;

namespace Application.User.Commands;
public sealed record CreateUserCommand(string UserName, Role Role, string NIC, Gender Gender, string EmailAddress, string PhoneNumber) : ICommand;
