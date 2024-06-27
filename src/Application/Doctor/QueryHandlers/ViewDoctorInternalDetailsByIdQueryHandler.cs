using Application.Abstractions.CQRS;
using Application.Abstractions.ReadOnlyRepositories;
using Application.Common;
using Application.Doctor.Views;

using Domain.Common;
using Domain.ValueObjects;

namespace Application.Doctor.QueryHandlers;
internal class ViewDoctorInternalDetailsByIdQueryHandler : IQueryHandler<DoctorDetailViewInternal, IdQuery>
{
    private readonly IReadOnlyDoctorRepository _doctorRepository;

    public ViewDoctorInternalDetailsByIdQueryHandler(IReadOnlyDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Result<DoctorDetailViewInternal>> HandleAsync(IdQuery query, CancellationToken cancellationToken = default)
    {
        var id = Id.CreateId(query.Id);

        return await _doctorRepository.GetDoctorDetailsForInternalAsync(id, cancellationToken);
    }
}
