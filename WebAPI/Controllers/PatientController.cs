using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/patient/")]
public class PatientController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> CreateAccountAsync([FromBody] object newPatientData)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"/associated/{userId}")]
    public Task<IActionResult> ListAssociatedPatientsAsync([FromRoute] string userId, [FromQuery] object pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{patientId}")]
    public Task<IActionResult> ViewPatientAsync([FromRoute] string patientId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route(@"{patientId}")]
    public Task<IActionResult> DeleteAccountAsync([FromRoute] string patientId)
    {
        throw new NotImplementedException();
    }
}
