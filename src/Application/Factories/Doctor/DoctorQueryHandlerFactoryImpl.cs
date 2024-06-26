using Application.Abstractions.CQRS;
using Application.Abstractions.Factories.Doctor;
using Application.Abstractions.ReadOnlyRepositories;
using Application.Common;
using Application.Doctor.Queries;
using Application.Doctor.QueryHandlers;
using Application.Doctor.Views;

namespace Application.Factories.Doctor;

internal sealed class DoctorQueryHandlerFactoryImpl : IDoctorQueryHandlerFactory
{
    private readonly IReadOnlyDoctorRepository _doctorRepository;

    private IQueryHandler<IReadOnlyCollection<DoctorListItem>, FilterDoctorQuery>? _listViewHandler;
    private IQueryHandler<DoctorDetailViewInternal, IdQuery>? _internalDetailViewHandler;
    private IQueryHandler<DoctorDetailViewPublic, IdQuery>? _publicDetailViewHandler;

    public DoctorQueryHandlerFactoryImpl(IReadOnlyDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public IQueryHandler<IReadOnlyCollection<DoctorListItem>, FilterDoctorQuery> DoctorListViewQueryHandler
        => _listViewHandler ??= new ListDoctorsQueryHandler(_doctorRepository);

    public IQueryHandler<DoctorDetailViewInternal, IdQuery> DoctorInternalDetailViewQueryHandler
        => _internalDetailViewHandler ??= new ViewDoctorInternalDetailsByIdQueryHandler(_doctorRepository);

    public IQueryHandler<DoctorDetailViewPublic, IdQuery> DoctorPublicDetailViewQueryHandler
        => _publicDetailViewHandler ??= new ViewDoctorPublicDetailsByIdQueryHandler(_doctorRepository);
}