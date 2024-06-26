using Application.Abstractions.CQRS;
using Application.Abstractions.ReadOnlyRepositories;
using Application.CustomFilters;
using Application.Patient.Queries;
using Application.Patient.Views;
using Domain.Common;
using Domain.Common.Errors;
using Domain.ValueObjects;

namespace Application.Patient.QueryHandlers;
internal class ViewFilteredPatientListQueryHandler : IQueryHandler<IReadOnlyCollection<PatientListItemView>, PatientFilterQuery>
{
    private readonly IReadOnlyPatientRepository _patientRepository;

    public ViewFilteredPatientListQueryHandler(IReadOnlyPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<IReadOnlyCollection<PatientListItemView>>> HandleAsync(
        PatientFilterQuery query,
        CancellationToken cancellationToken = default)
    {
        var paginationResult = Pagination.Create(query.Pagination.ResultsPerPage, query.Pagination.PageNumber);
        if (paginationResult.IsFailure)
        {
            return Result<IReadOnlyCollection<PatientListItemView>>.Failure(paginationResult.Error);
        }

        if (query.AgeGreaterThan is not null && query.AgeGreaterThan <= 0)
        {
            return Result<IReadOnlyCollection<PatientListItemView>>.Failure(DateOfBirthErrors.AgeIsZeroOrNegative);
        }
        
        if (query.AgeLowerThan is not null && query.AgeLowerThan <= 0)
        {
            return Result<IReadOnlyCollection<PatientListItemView>>.Failure(DateOfBirthErrors.AgeIsZeroOrNegative);
        }

        var filter = PatientFilter.CreateFilter(
            paginationResult.Value,
            query.PartOfName,
            query.Gender,
            query.AgeGreaterThan,
            query.AgeLowerThan);

        return await _patientRepository.GetPatientListAsync(filter, cancellationToken);
    }
}
