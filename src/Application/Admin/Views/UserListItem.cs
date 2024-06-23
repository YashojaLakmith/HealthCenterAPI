using Domain.Enum;

namespace Application.Admin.Views;
public sealed record UserListItem(Guid UserId, string UserName, Role Role);
