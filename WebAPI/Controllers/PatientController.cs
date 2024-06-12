using Microsoft.AspNetCore.Mvc;

using WebAPI.DataTransferObjects.Common;
using WebAPI.DataTransferObjects.Patient;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/patient/")]
public class PatientController : ControllerBase
{
    [HttpPost]
    [Route(@"generic/")]
    public Task<IActionResult> CreateAccountAsync(
        [FromBody] CreateNewPatient newPatientData)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route(@"associative/")]
    public Task<IActionResult> CreateAssociativePatientAsync(
        [FromBody] CreateAssociativePatient associativePatient)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"/associated/{userId}")]
    public Task<IActionResult> ListAssociatedPatientsAsync(
        [FromRoute] string userId,
        [FromQuery] Pagination pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{patientId}")]
    public Task<IActionResult> ViewPatientAsync(
        [FromRoute] string patientId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route(@"{patientId}")]
    public Task<IActionResult> DeleteAccountAsync(
        [FromRoute] string patientId)
    {
        throw new NotImplementedException();
    }
}
