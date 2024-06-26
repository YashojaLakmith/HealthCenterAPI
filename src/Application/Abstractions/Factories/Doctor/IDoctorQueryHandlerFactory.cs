using Application.Abstractions.CQRS;
using Application.Common;
using Application.Doctor.Queries;
using Application.Doctor.Views;
using Domain.Common;

namespace Application.Abstractions.Factories.Doctor;

public interface IDoctorQueryHandlerFactory
{
    IQueryHandler<IReadOnlyCollection<DoctorListItem>, FilterDoctorQuery> DoctorListViewQueryHandler { get; }
    IQueryHandler<DoctorDetailViewInternal, IdQuery> DoctorInternalDetailViewQueryHandler { get; }
    IQueryHandler<DoctorDetailViewPublic, IdQuery> DoctorPublicDetailViewQueryHandler { get; }
}