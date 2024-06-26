using Domain.Enum;
using Domain.ValueObjects;

namespace Application.CustomFilters;

public class AppointmentFilter
{
    public Id? PatientId { get; }
    
    public AppointmentStatus? AppointmentStatus { get; }
    
    public Pagination Pagination { get; set; }

    internal static AppointmentFilter CreateFilter(
        Pagination pagination,
        Id? patientId = null,
        AppointmentStatus? appointmentStatus = null)
    {
        return new AppointmentFilter(pagination, patientId, appointmentStatus);
    }

    private AppointmentFilter(Pagination pagination, Id? patientId, AppointmentStatus? appointmentStatus)
    {
        PatientId = patientId;
        AppointmentStatus = appointmentStatus;
        Pagination = pagination;
    }
}