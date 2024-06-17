using Application.Abstractions.CQRS;
using Application.Patient.Queries;
using Application.Patient.Views;

using Domain.Common;

namespace Application.Patient.QueryHandlers;
internal class ViewFilteredPatientListQueryHandler : IQueryHandler<IReadOnlyCollection<PatientListItemView>, PatientFilterQuery>
{
    public Task<Result<IReadOnlyCollection<PatientListItemView>>> HandleAsync(PatientFilterQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
