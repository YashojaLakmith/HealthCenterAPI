using Application.Abstractions.CQRS;
using Application.Common;
using Application.Doctor.Views;

using Domain.Common;

namespace Application.Doctor.QueryHandlers;
internal class ViewDoctorPublicDetailsByIdQueryHandler : IQueryHandler<DoctorDetailViewPublic, IdCommandQuery>
{
    public Task<Result<DoctorDetailViewPublic>> HandleAsync(IdCommandQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
