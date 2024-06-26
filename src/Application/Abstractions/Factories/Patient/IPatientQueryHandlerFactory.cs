using Application.Abstractions.CQRS;
using Application.Common;
using Application.Patient.Queries;
using Application.Patient.Views;

namespace Application.Abstractions.Factories.Patient;

public interface IPatientQueryHandlerFactory
{
    IQueryHandler<IReadOnlyCollection<PatientListItemView>, PatientFilterQuery> PatientListViewQueryHandler { get; }
    IQueryHandler<PatientDetailView, IdQuery> PatientDetailViewByIdQueryHandler { get; }
    IQueryHandler<PatientDetailView, NICQuery> PatientDetailViewByNicQueryHandler { get; }
}