using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/lab/")]
public class LabWorkerController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> CreateLabWorkerAsync([FromBody] object createLabWorkerData)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> ListLabWorkersAsync([FromQuery] object pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{labWorkerId}/")]
    public Task<IActionResult> ViewLabWorkersAsync([FromRoute] string labWorkerId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    public Task<IActionResult> ModifyLabWorkerPassword([FromBody] object passwordChangeData)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task<IActionResult> DeleteLabWorkerAccount([FromRoute] string labWorkerId)
    {
        throw new NotImplementedException();
    }
}
