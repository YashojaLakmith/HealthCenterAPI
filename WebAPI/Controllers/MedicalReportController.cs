using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/report/")]
public class MedicalReportController : ControllerBase
{
    [HttpGet]
    [Route(@"{reportId}")]
    public Task<IActionResult> ViewReportAsync([FromRoute] string reportId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> ViewReportListAsync([FromQuery] object pagination)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<IActionResult> CreateReportAsync([FromBody] object reportData, IFormFile reportFile)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"{reportId}/accept/")]
    public Task<IActionResult> AcceptReportAsync([FromRoute] string reportId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"{reportId}/reject/")]
    public Task<IActionResult> RejectReportAsync([FromRoute] string reportId)
    {
        throw new NotImplementedException();
    }
}
