using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/prescription/")]
public class PrescriptionController : ControllerBase
{
    [HttpGet]
    [Route(@"{userId}/")]
    public Task<IActionResult> ListUserPrescriptionsAsync([FromRoute] string userId, [FromQuery] bool exceptIssued, [FromQuery] object pagination)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<IActionResult> CreatePrescriptionAsync([FromBody] object newPrescriptionInfo)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{userId}/{prescriptionId}")]
    public Task<IActionResult> ViewPrescriptionAsync([FromRoute] string userId, [FromRoute] string prescriptionId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route(@"{userId}/{prescriptionId}")]
    public Task<IActionResult> DeletePrescriptionAsync([FromRoute] string userId, [FromRoute] string prescriptionId)
    {
        throw new NotImplementedException();
    }
}
