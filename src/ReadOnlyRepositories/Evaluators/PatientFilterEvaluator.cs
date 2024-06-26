using Application.CustomFilters;
using Domain.Entities;
using Domain.Enum;

namespace ReadOnlyRepositories.Evaluators;

internal static class PatientFilterEvaluator
{
    internal static IQueryable<Patient> EvaluateFilter(this IQueryable<Patient> query, PatientFilter filter)
    {
        query = ApplyNamePartFilter(query, filter.PartOfName);
        query = ApplyGenderFilter(query, filter.Gender);
        query = ApplyMinAgeFilter(query, filter.AgeGreaterThan);
        query = ApplyMaxAgeFilter(query, filter.AgeLowerThan);

        return query
            .OrderBy(patient => patient.PatientName.Value)
            .ApplyPagination(filter.Pagination);
    }

    private static IQueryable<Patient> ApplyNamePartFilter(IQueryable<Patient> query, string? partOfName)
    {
        return partOfName is null
            ? query
            : query.Where(patient =>
                patient.PatientName.Value.Contains(partOfName, StringComparison.OrdinalIgnoreCase));
    }
    
    private static IQueryable<Patient> ApplyGenderFilter(IQueryable<Patient> query, Gender? gender)
    {
        return gender is null
            ? query
            : query.Where(patient => patient.Gender == gender);
    }

    private static IQueryable<Patient> ApplyMinAgeFilter(IQueryable<Patient> query, int? lowerLimit)
    {
        return lowerLimit is null
            ? query
            : query.Where(patient => GetAge(patient.DateOfBirth.Value) >= lowerLimit);
    }

    private static IQueryable<Patient> ApplyMaxAgeFilter(IQueryable<Patient> query, int? upperLimit)
    {
        return upperLimit is null
            ? query
            : query.Where(patient => GetAge(patient.DateOfBirth.Value) <= upperLimit);
    }

    private static int GetAge(DateTime dateOfBirth)
    {
        return DateTime.UtcNow.Year - dateOfBirth.Year;
    }
}