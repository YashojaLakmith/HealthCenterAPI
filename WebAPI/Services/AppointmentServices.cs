using WebAPI.Abstractions.API;
using WebAPI.DataTransferObjects.Appointment;
using WebAPI.DataTransferObjects.Common;

namespace WebAPI.Services;

public class AppointmentServices
{
    private readonly IUserExtractor _userExtractor;

    public AppointmentServices(IUserExtractor userExtractor)
    {
        _userExtractor = userExtractor;
    }

    public Task CreateAppointmentAsync(NewAppointment newAppointment)
    {
        throw new NotImplementedException();
    }

    public Task MarkUserArrivedForAppointmentAsync(string appointmentId)
    {
        throw new NotImplementedException();
    }

    public Task MarkUserUserBeingServedAsync(string appointmentId)
    {
        throw new NotImplementedException();
    }

    public Task MarkUserWasServedAsync(string appointmentId)
    {
        throw new NotImplementedException();
    }

    public Task CancelAppointmentAsync(string appointmentId)
    {
        throw new NotImplementedException();
    }

    public Task<AppointmentListItem_Patient> DetailViewByPatientAsync(string appointmentId)
    {
        throw new NotImplementedException();
    }

    public Task<AppointmentDetailView_Server> DetailViewByServerAsync(string appointmentId)
    {
        throw new NotImplementedException();
    }

    public Task<AppointmentListItem_Patient> ListForPatientAsync(Pagination pagination)
    {
        throw new NotImplementedException();
    }

    public Task<AppointmentListItem_Server> ListForServerAsync(Pagination pagination)
    {
        throw new NotImplementedException();
    }
}
