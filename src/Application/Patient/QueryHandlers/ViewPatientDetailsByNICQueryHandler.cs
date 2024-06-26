using Application.Abstractions.CQRS;
using Application.Abstractions.ReadOnlyRepositories;
using Application.Patient.Queries;
using Application.Patient.Views;
using Domain.Common;
using Domain.ValueObjects;

namespace Application.Patient.QueryHandlers;
internal class ViewPatientDetailsByNICQueryHandler : IQueryHandler<PatientDetailView, NICQuery>
{
    private readonly IReadOnlyPatientRepository _patientRepository;

    public ViewPatientDetailsByNICQueryHandler(IReadOnlyPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<PatientDetailView>> HandleAsync(NICQuery query, CancellationToken cancellationToken = default)
    {
        var nicResult = NIC.Create(query.NICNumber);
        if (nicResult.IsFailure)
        {
            return Result<PatientDetailView>.Failure(nicResult.Error);
        }

        return await _patientRepository.GetPatientDetailViewAsync(nicResult.Value, cancellationToken);
    }
}
