using Domain.ValueObjects;

namespace Application.CustomFilters;

public class DoctorFilter
{
    public string? PartOfName { get; }
    public Pagination Pagination { get; }

    internal static DoctorFilter CreateFilter(Pagination pagination, string? partOfName = null)
    {
        return new DoctorFilter(partOfName, pagination);
    }
    
    private DoctorFilter(string? partOfName, Pagination pagination)
    {
        Pagination = pagination;
        PartOfName = partOfName;
    }
}