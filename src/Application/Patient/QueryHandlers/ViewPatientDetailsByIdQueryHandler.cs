using Application.Abstractions.CQRS;
using Application.Common;
using Application.Patient.Views;

using Domain.Common;

namespace Application.Patient.QueryHandlers;
internal class ViewPatientDetailsByIdQueryHandler : IQueryHandler<PatientDetailView, IdQuery>
{
    public Task<Result<PatientDetailView>> HandleAsync(IdQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
