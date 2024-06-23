using Application.Abstractions.CQRS;
using Application.Common;
using Application.Doctor.Views;

using Domain.Common;

namespace Application.Doctor.QueryHandlers;
internal class ViewDoctorPublicDetailsByIdQueryHandler : IQueryHandler<DoctorDetailViewPublic, IdQuery>
{
    public Task<Result<DoctorDetailViewPublic>> HandleAsync(IdQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
