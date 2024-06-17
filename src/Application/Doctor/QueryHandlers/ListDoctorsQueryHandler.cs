using Application.Abstractions.CQRS;
using Application.Doctor.Queries;
using Application.Doctor.Views;

using Domain.Common;

namespace Application.Doctor.QueryHandlers;
internal class ListDoctorsQueryHandler : IQueryHandler<IReadOnlyCollection<DoctorListItem>, FilterDoctorQuery>
{
    public Task<Result<IReadOnlyCollection<DoctorListItem>>> HandleAsync(FilterDoctorQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
