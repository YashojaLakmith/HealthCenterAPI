using Application.Abstractions.CQRS;
using Application.Abstractions.Factories.Patient;
using Application.Abstractions.ReadOnlyRepositories;
using Application.Common;
using Application.Patient.Queries;
using Application.Patient.QueryHandlers;
using Application.Patient.Views;

namespace Application.Factories.Patient;

internal sealed class PatientQueryHandlerFactoryImpl : IPatientQueryHandlerFactory
{
    private readonly IReadOnlyPatientRepository _patientRepository;

    private IQueryHandler<IReadOnlyCollection<PatientListItemView>, PatientFilterQuery>? _listViewHandler;
    private IQueryHandler<PatientDetailView, IdQuery>? _detailViewByIdHandler;
    private IQueryHandler<PatientDetailView, NICQuery>? _detailViewByNicHandler;

    public PatientQueryHandlerFactoryImpl(IReadOnlyPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public IQueryHandler<IReadOnlyCollection<PatientListItemView>, PatientFilterQuery> PatientListViewQueryHandler
        => _listViewHandler ??= new ViewFilteredPatientListQueryHandler(_patientRepository);

    public IQueryHandler<PatientDetailView, IdQuery> PatientDetailViewByIdQueryHandler
        => _detailViewByIdHandler ??= new ViewPatientDetailsByIdQueryHandler(_patientRepository);

    public IQueryHandler<PatientDetailView, NICQuery> PatientDetailViewByNicQueryHandler
        => _detailViewByNicHandler ??= new ViewPatientDetailsByNICQueryHandler(_patientRepository);
}