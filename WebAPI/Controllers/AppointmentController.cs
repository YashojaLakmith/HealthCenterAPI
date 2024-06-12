using Microsoft.AspNetCore.Mvc;

using WebAPI.DataTransferObjects.Appointment;
using WebAPI.DataTransferObjects.Common;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/appointment/")]
public class AppointmentController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> CreateAppointmentAsync(
        [FromBody] NewAppointment newAppointment)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> ListAppointmentsAsync(
        [FromQuery] Pagination pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{appointmentId}")]
    public Task<IActionResult> ViewAppointmentAsync(
        [FromRoute] string appointmentId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route(@"{appointmentId}")]
    public Task<IActionResult> CancelAppointmentAsync(
        [FromRoute] string appointmentId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"{appointmentId}/mark-arrived")]
    public Task<IActionResult> MarkUserArrivedAsync(
        [FromRoute] string appointmentId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"{appointmentId}/mark-in-progress")]
    public Task<IActionResult> MarkUserBeingAttendedAsync(
        [FromRoute] string appointmentId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"{appointmentId}/mark-done")]
    public Task<IActionResult> MarkUserWasServedAsync(
        [FromRoute] string appointmentId)
    {
        throw new NotImplementedException();
    }
}
