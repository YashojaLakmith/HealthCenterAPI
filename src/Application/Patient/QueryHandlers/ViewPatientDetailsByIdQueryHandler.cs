using Application.Abstractions.CQRS;
using Application.Common;
using Application.Patient.Views;

using Domain.Common;

namespace Application.Patient.QueryHandlers;
internal class ViewPatientDetailsByIdQueryHandler : IQueryHandler<PatientDetailView, IdCommandQuery>
{
    public Task<Result<PatientDetailView>> HandleAsync(IdCommandQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
