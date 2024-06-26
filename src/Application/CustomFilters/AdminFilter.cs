using Domain.Enum;
using Domain.ValueObjects;

namespace Application.CustomFilters;

public class AdminFilter
{
    public string? PartOfName { get; }
    public Role? Role { get; }
    public Pagination Pagination { get; }

    internal static AdminFilter CreateFilter(Pagination pagination, string? partOfName = null, Role? role = null)
    {
        return new AdminFilter(partOfName, role, pagination);
    }

    private AdminFilter(string? partOfName, Role? role, Pagination pagination)
    {
        PartOfName = partOfName;
        Role = role;
        Pagination = pagination;
    }
}