using Application.Abstractions.CQRS;
using Application.Common;
using Application.Doctor.Views;

using Domain.Common;

namespace Application.Doctor.QueryHandlers;
internal class ViewDoctorInternalDetailsByIdQueryHandler : IQueryHandler<DoctorDetailViewInternal, IdQuery>
{
    public Task<Result<DoctorDetailViewInternal>> HandleAsync(IdQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
