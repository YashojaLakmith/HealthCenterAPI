using Microsoft.AspNetCore.Mvc;

using Services.DataTransferObjects.Common;
using Services.DataTransferObjects.LabWorker;
using Services.DataTransferObjects.LoginAndPasswords;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/lab/")]
public class LabWorkerController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> CreateLabWorkerAsync(
        [FromBody] CreateLabWorker createLabWorkerData)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> ListLabWorkersAsync(
        [FromQuery] Pagination pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{labWorkerId}/")]
    public Task<IActionResult> ViewLabWorkersAsync(
        [FromRoute] string labWorkerId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    public Task<IActionResult> ModifyLabWorkerPassword(
        [FromBody] ChangePasswordInformation passwordChangeData)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task<IActionResult> DeleteLabWorkerAccount(
        [FromRoute] string labWorkerId)
    {
        throw new NotImplementedException();
    }
}
