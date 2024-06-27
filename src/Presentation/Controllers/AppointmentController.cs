using Application.Abstractions.Factories.Appointment;
using Application.Appointment.Commands;
using Application.Appointment.Queries;
using Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route(@"appointment/")]
public class AppointmentController(
    IAppointmentCommandHandlerFactory commandHandlers,
    IAppointmentQueryHandlerFactory queryHandlers)
    : BaseController
{
    private readonly IAppointmentCommandHandlerFactory _commandHandlers = commandHandlers;
    private readonly IAppointmentQueryHandlerFactory _queryHandlers = queryHandlers;

    [HttpGet]
    [Route(@"{appointmentId}/")]
    public async Task<IActionResult> ViewAppointmentDetailsAsync(
        [FromRoute] IdQuery appointmentId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<IActionResult> ViewAppointmentListAsync(
        [FromBody] AppointmentFilterQuery filter)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAppointmentAsync(
        [FromBody] NewAppointmentCommand newAppointmentDetails)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route(@"{appointmentId}/")]
    public async Task<IActionResult> CancelAppointmentAsync(
        [FromRoute] IdCommand appointmentId)
    {
        throw new NotImplementedException();
    }
}
