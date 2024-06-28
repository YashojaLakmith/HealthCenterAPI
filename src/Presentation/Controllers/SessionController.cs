using Application.Abstractions.Factories.Session;
using Application.Common;
using Application.Session.Commands;
using Application.Session.Queries;
using Application.Session.Views;
using Domain.Common;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.DataTransferObjects.Session;
using Presentation.Utilities;

namespace Presentation.Controllers;

[NestedRoute<SessionController>(@"session/")]
public class SessionController(
    ISessionCommandHandlerFactory commandHandler,
    ISessionQueryHandlerFactory queryHandlers,
    ILogger<SessionController> logger)
    : BaseController(logger)
{
    [HttpGet]
    [Route(@"{sessionId:guid}/")]
    [ProducesResponseType(typeof(SessionDetailView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ViewSessionDetailsAsync(
        [FromRoute] Guid sessionId)
    {
        return await HandleActionAsync(async () =>
        {
            var result =
                await queryHandlers.SessionDetailViewQueryHandler.HandleAsync(new IdQuery(sessionId));
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
    [Route(@"by-doctor/")]
    [ProducesResponseType(typeof(IReadOnlyCollection<SessionListItemView>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ListSessionsByDoctorAsync(
        [FromBody] SessionFilterByDoctorIdQuery filter)
    {
        return await HandleActionAsync(async () =>
        {
            var result = 
                await queryHandlers.SessionListViewByDoctorIdQueryHandler.HandleAsync(filter);
            return result.IsFailure
                ? BadRequest(result.Error)
                : Ok(result.Value);
        });
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<SessionListItemView>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ListAllSessionsAsync(
        [FromBody] SessionFilterQuery filter)
    {
        return await HandleActionAsync(async () =>
        {
            var result = 
                await queryHandlers.SessionListViewQueryHandler.HandleAsync(filter);
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
    public async Task<IActionResult> CreateSessionAsync(
        [FromBody] CreateSessionCommand newSessionInformation)
    {
        return await HandleActionAsync(async () =>
        {
            var result = await commandHandler.CreateSessionCommandHandler.HandleAsync(newSessionInformation);
            return result.IsFailure
                ? BadRequest(result.Error)
                : StatusCode(StatusCodes.Status201Created);
        });
    }

    [HttpPatch]
    [Route(@"{sessionId:guid}/")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ModifySessionTimesAsync(
        [FromRoute] Guid sessionId,
        [FromBody] SessionTimes newSessionTimes)
    {
        var command = new ModifySessionTimeCommand(
            sessionId,
            newSessionTimes.SessionStartTime,
            newSessionTimes.SessionEndTime);

        return await HandleActionAsync(async () =>
        {
            var result = await commandHandler.ModifySessionTimeCommandHandler.HandleAsync(command);
            if (result.IsSuccess)
            {
                return NoContent();
            }

            return result.Error == RepositoryErrors.NotFoundError
                ? NotFound(result.Error)
                : BadRequest(result.Error);
        });
    }

    [HttpDelete]
    [Route(@"{doctorId:guid}/{sessionId:guid}/")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteSessionAsync(
        [FromRoute] Guid doctorId,
        [FromRoute] Guid sessionId)
    {
        var command = new DeleteSessionCommand(
            doctorId,
            sessionId);
        return await HandleActionAsync(async () =>
        {
            var result = await commandHandler.DeleteSessionCommandHandler.HandleAsync(command);
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
