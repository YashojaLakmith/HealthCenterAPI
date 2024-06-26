using Application.Admin.Views;
using Domain.Entities;

namespace ReadOnlyRepositories.Extensions;

internal static class AdminExtensions
{
    internal static AdminDetailView AsDetailView(this Admin admin)
    {
        return new AdminDetailView(
            admin.Id.Value,
            admin.AdminName.Value,
            admin.NIC.Value,
            admin.PhoneNumber.Value,
            admin.EmailAddress.Value,
            admin.Gender,
            admin.Role,
            admin.CreatedOn);
    }

    internal static AdminListItem AsListItem(this Admin admin)
    {
        return new AdminListItem(
            admin.Id.Value,
            admin.AdminName.Value,
            admin.Role);
    }
}