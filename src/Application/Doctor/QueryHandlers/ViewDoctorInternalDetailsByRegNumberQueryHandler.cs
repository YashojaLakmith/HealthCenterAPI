using Application.Abstractions.CQRS;
using Application.Doctor.Queries;
using Application.Doctor.Views;

using Domain.Common;

namespace Application.Doctor.QueryHandlers;
internal class ViewDoctorInternalDetailsByRegNumberQueryHandler : IQueryHandler<DoctorDetailViewInternal, RegistrationNumberQuery>
{
    public Task<Result<DoctorDetailViewInternal>> HandleAsync(RegistrationNumberQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
