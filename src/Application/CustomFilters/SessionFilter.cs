using Domain.ValueObjects;

namespace Application.CustomFilters;

public class SessionFilter
{
    public string? PartOfDoctorName { get; }
    public DateTime? BeginsAfter { get; }
    public DateTime? EndsBefore { get; }
    public Pagination Pagination { get; }

    internal static SessionFilter CreateFilter(
        Pagination pagination,
        string? partOfDoctorName = null,
        DateTime? beginsAfter = null,
        DateTime? endsBefore = null)
    {
        return new SessionFilter(
            partOfDoctorName,
            beginsAfter,
            endsBefore,
            pagination);
    }

    private SessionFilter(
        string? partOfName,
        DateTime? beginsAfter,
        DateTime? endsBefore,
        Pagination pagination)
    {
        PartOfDoctorName = partOfName;
        BeginsAfter = beginsAfter;
        EndsBefore = endsBefore;
        Pagination = pagination;
    }
}