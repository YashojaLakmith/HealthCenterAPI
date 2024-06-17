using Application.Abstractions.CQRS;
using Application.Common;
using Application.Doctor.Views;

using Domain.Common;

namespace Application.Doctor.QueryHandlers;
internal class ViewDoctorInternalDetailsByIdQueryHandler : IQueryHandler<DoctorDetailViewInternal, IdCommandQuery>
{
    public Task<Result<DoctorDetailViewInternal>> HandleAsync(IdCommandQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
