using Microsoft.AspNetCore.Mvc;

using Services.DataTransferObjects.Common;
using Services.DataTransferObjects.Schedule;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/schedule/")]
public class ScheduleController : ControllerBase
{
    [HttpGet]
    [Route(@"scheduled/")]
    public Task<IActionResult> ListScheduledRoomsAsync(
        [FromQuery] Pagination pagination,
        [FromBody] DateRange dateTimeParams)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"unscheduled/")]
    public Task<IActionResult> ListUnScheduledRoomsAsync(
        [FromQuery] Pagination pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{scheduleId}")]
    public Task<IActionResult> ViewSheduledRoomInformationAsync(
        [FromRoute] string scheduleId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<IActionResult> ScheduleAsync(
        [FromBody] NewSchedule scheduleInfo)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route(@"{scheduleId}")]
    public Task<IActionResult> CancelScheduleAsync(
        [FromRoute] string scheduleId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"{scheduleId}/start")]
    public Task<IActionResult> NotifyScheduledSessionStartedAsync(
        [FromRoute] string scheduleId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"{scheduleId}/end")]
    public Task<IActionResult> NotifyScheduledSessionFinishedAsync(
        [FromRoute] string scheduleId)
    {
        throw new NotImplementedException();
    }
}