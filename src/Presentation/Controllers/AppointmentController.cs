using Application.Abstractions.Factories.Appointment;
using Application.Appointment.Commands;
using Application.Appointment.Queries;
using Application.Appointment.Views;
using Application.Common;
using Domain.Common;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Utilities;

namespace Presentation.Controllers;

[NestedRoute<AppointmentController>(@"appointment/")]
public class AppointmentController(
    IAppointmentCommandHandlerFactory commandHandlers,
    IAppointmentQueryHandlerFactory queryHandlers,
    ILogger<AppointmentController> logger)
    : BaseController(logger)
{
    [HttpGet]
    [Route(@"{appointmentId:guid}/")]
    [ProducesResponseType(typeof(AppointmentDetailView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ViewAppointmentDetailsAsync(
        [FromRoute] Guid appointmentId)
    {
        return await HandleActionAsync(async () =>
        {
            var query = new IdQuery(appointmentId);
            var result = await queryHandlers.ViewAppointmentDetailViewQueryHandler.HandleAsync(query);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return result.Error == RepositoryErrors.NotFoundError
                ? NotFound(result.Error)
                : BadRequest(result.Error);
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<AppointmentListItemView>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ViewAppointmentListAsync(
        [FromBody] AppointmentFilterQuery filter)
    {
        return await HandleActionAsync(async () =>
        {
            var result = await queryHandlers.ViewAppointmentListQueryHandler.HandleAsync(filter);
            return result.IsFailure
                ? BadRequest(result.Error)
                : Ok(result.Value);
        });
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAppointmentAsync(
        [FromBody] NewAppointmentCommand newAppointmentDetails)
    {
        return await HandleActionAsync(async () =>
        {
            var result = await commandHandlers.CreateAppointmentCommandHandler.HandleAsync(newAppointmentDetails);
            return result.IsFailure
                ? BadRequest(result.Error)
                : StatusCode(StatusCodes.Status201Created);
        });
    }

    [HttpDelete]
    [Route(@"{appointmentId:guid}/")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CancelAppointmentAsync(
        [FromRoute] Guid appointmentId)
    {
        return await HandleActionAsync(async () =>
        {
            var command = new IdCommand(appointmentId);
            var result = await commandHandlers.CancelAppointmentCommandHandler.HandleAsync(command);
            if (result.IsSuccess)
            {
                return NoContent();
            }

            return result.Error == RepositoryErrors.NotFoundError
                ? NotFound(result.Error)
                : BadRequest(result.Error);
        });
    }
}
