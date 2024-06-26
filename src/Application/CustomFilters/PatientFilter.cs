using Domain.Enum;
using Domain.ValueObjects;

namespace Application.CustomFilters;

public class PatientFilter
{
    public string? PartOfName { get; }
    public Gender? Gender { get; }
    public int? AgeGreaterThan { get; }
    public int? AgeLowerThan { get; }
    public Pagination Pagination { get; }

    internal static PatientFilter CreateFilter(
        Pagination pagination,
        string? partOfName = null,
        Gender? gender = null,
        int? ageGreaterThan = null,
        int? ageLowerThan = null)
    {
        return new PatientFilter(
            partOfName,
            gender,
            ageGreaterThan,
            ageLowerThan,
            pagination);
    }

    private PatientFilter(
        string? partOfName,
        Gender? gender,
        int? ageGreaterThan,
        int? ageLowerThan,
        Pagination pagination)
    {
        PartOfName = partOfName;
        Gender = gender;
        AgeGreaterThan = ageGreaterThan;
        AgeLowerThan = ageLowerThan;
        Pagination = pagination;
    }
}