using Application.Abstractions.CQRS;
using Application.Abstractions.ReadOnlyRepositories;
using Application.CustomFilters;
using Application.Doctor.Queries;
using Application.Doctor.Views;

using Domain.Common;
using Domain.ValueObjects;

namespace Application.Doctor.QueryHandlers;
internal class ListDoctorsQueryHandler : IQueryHandler<IReadOnlyCollection<DoctorListItem>, FilterDoctorQuery>
{
    private readonly IReadOnlyDoctorRepository _doctorRepository;

    public ListDoctorsQueryHandler(IReadOnlyDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Result<IReadOnlyCollection<DoctorListItem>>> HandleAsync(FilterDoctorQuery query, CancellationToken cancellationToken = default)
    {
        var paginationResult = Pagination.Create(query.Pagination.ResultsPerPage, query.Pagination.PageNumber);
        if (paginationResult.IsFailure)
        {
            return Result<IReadOnlyCollection<DoctorListItem>>.Failure(paginationResult.Error);
        }

        var filter = DoctorFilter.CreateFilter(paginationResult.Value, query.NamePart);

        return await _doctorRepository.GetDoctorListAsync(filter, cancellationToken);
    }
}
