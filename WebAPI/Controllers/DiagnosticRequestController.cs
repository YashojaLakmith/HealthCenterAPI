using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/diagnostic-request/")]
public class DiagnosticRequestController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> CreateDiagnosticRequestAsync([FromBody] object diagnosticRequest)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"user/{userId}/")]
    public Task<IActionResult> ListUserDiagnosticRequestsAsync([FromRoute] string userId, [FromQuery] bool exceptCompleted, [FromQuery] object pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"doctor/{docId}/")]
    public Task<IActionResult> ListDoctorDiagnosticRequestsAsync([FromRoute] string docId, [FromQuery] bool exceptCompleted, [FromQuery] object pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> GetDiagnosticRequestAsync([FromRoute] string requestId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route(@"{requestId}")]
    public Task<IActionResult> RemoveDiagnosticRequestAsync([FromRoute] string requestId)
    {
        throw new NotImplementedException();
    }
}
