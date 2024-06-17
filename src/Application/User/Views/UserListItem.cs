using Domain.Enum;

namespace Application.User.Views;
public sealed record UserListItem(Guid UserId, string UserName, Role Role);
