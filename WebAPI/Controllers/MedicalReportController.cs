using Microsoft.AspNetCore.Mvc;

using WebAPI.DataTransferObjects.Common;
using WebAPI.DataTransferObjects.MedicalReport;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/report/")]
public class MedicalReportController : ControllerBase
{
    [HttpGet]
    [Route(@"{reportId}")]
    public Task<IActionResult> ViewReportAsync(
        [FromRoute] string reportId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> ViewReportListAsync(
        [FromQuery] Pagination pagination)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<IActionResult> CreateReportAsync(
        [FromBody] NewReport reportData,
        IFormFile reportFile)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"{reportId}/accept/")]
    public Task<IActionResult> AcceptReportAsync(
        [FromRoute] string reportId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"{reportId}/reject/")]
    public Task<IActionResult> RejectReportAsync(
        [FromRoute] string reportId)
    {
        throw new NotImplementedException();
    }
}
