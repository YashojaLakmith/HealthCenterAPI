using Microsoft.AspNetCore.Mvc;

using WebAPI.DataTransferObjects.Common;
using WebAPI.DataTransferObjects.DiagnosticRequest;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/diagnostic-request/")]
public class DiagnosticRequestController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> CreateDiagnosticRequestAsync(
        [FromBody] NewDiagnosticRequest diagnosticRequest)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"user/{userId}/")]
    public Task<IActionResult> ListUserDiagnosticRequestsAsync(
        [FromRoute] string userId,
        [FromQuery] Pagination pagination,
        [FromQuery] bool exceptCompleted = true)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"doctor/{docId}/")]
    public Task<IActionResult> ListDoctorDiagnosticRequestsAsync(
        [FromRoute] string docId,
        [FromQuery] Pagination pagination,
        [FromQuery] bool exceptCompleted = true)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> GetDiagnosticRequestAsync(
        [FromRoute] string requestId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route(@"{requestId}")]
    public Task<IActionResult> RemoveDiagnosticRequestAsync(
        [FromRoute] string requestId)
    {
        throw new NotImplementedException();
    }
}
