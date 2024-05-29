using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/schedule/")]
public class ScheduleController : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> ListScheduledRoomsAsync([FromQuery] object pagination, [FromBody] object dateTimeParams)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{scheduleId}")]
    public Task<IActionResult> ViewSheduledRoomInformationAsync([FromRoute] string scheduleId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<IActionResult> ScheduleAsync([FromBody] object scheduleInfo)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route(@"{scheduleId}")]
    public Task<IActionResult> CancelScheduleAsync([FromRoute] string scheduleId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"{scheduleId}/start")]
    public Task<IActionResult> NotifyScheduledSessionStartedAsync([FromRoute] string scheduleId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"{scheduleId}/end")]
    public Task<IActionResult> NotifyScheduledSessionFinishedAsync([FromRoute] string scheduleId)
    {
        throw new NotImplementedException();
    }
}