using Application.Abstractions.CQRS;
using Application.Abstractions.ReadOnlyRepositories;
using Application.Common;
using Application.Patient.Views;
using Domain.Common;
using Domain.ValueObjects;

namespace Application.Patient.QueryHandlers;
internal class ViewPatientDetailsByIdQueryHandler : IQueryHandler<PatientDetailView, IdQuery>
{
    private readonly IReadOnlyPatientRepository _patientRepository;

    public ViewPatientDetailsByIdQueryHandler(IReadOnlyPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<PatientDetailView>> HandleAsync(IdQuery query, CancellationToken cancellationToken = default)
    {
        var idResult = Id.CreateId(query.Id);
        if (idResult.IsFailure)
        {
            return Result<PatientDetailView>.Failure(idResult.Error);
        }

        return await _patientRepository.GetPatientDetailViewAsync(idResult.Value, cancellationToken);
    }
}
