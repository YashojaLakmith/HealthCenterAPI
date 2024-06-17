using Domain.Enum;

namespace Application.Common;
public sealed record InvokingUser(Guid UserId, Role Role);
