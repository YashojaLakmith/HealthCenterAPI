using Application.Abstractions.CQRS;
using Application.Patient.Queries;
using Application.Patient.Views;

using Domain.Common;

namespace Application.Patient.QueryHandlers;
internal class ViewPatientDetailsByNICQueryHandler : IQueryHandler<PatientDetailView, NICQuery>
{
    public Task<Result<PatientDetailView>> HandleAsync(NICQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
