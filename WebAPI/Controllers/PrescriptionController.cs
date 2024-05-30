using Microsoft.AspNetCore.Mvc;

using Services.DataTransferObjects.Common;
using Services.DataTransferObjects.Prescription;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/prescription/")]
public class PrescriptionController : ControllerBase
{
    [HttpGet]
    [Route(@"patient/{patientId}/")]
    public Task<IActionResult> ListUserPrescriptionsAsync(
        [FromRoute] string patientId,
        [FromQuery] Pagination pagination,
        [FromQuery] bool exceptIssued = true)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<IActionResult> CreatePrescriptionAsync(
        [FromBody] NewPrescription newPrescriptionInfo)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{prescriptionId}")]
    public Task<IActionResult> ViewPrescriptionAsync(
        [FromRoute] string prescriptionId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"doctor/{doctorId}/")]
    public Task<IActionResult> ListPrescriptionsOfDoctorAsync(
        [FromRoute] string doctorId,
        [FromQuery] Pagination pagination)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    public Task<IActionResult> IssuePrescriptionAsync(
        [FromRoute] string prescriptionId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route(@"{prescriptionId}")]
    public Task<IActionResult> DeletePrescriptionAsync(
        [FromRoute] string prescriptionId)
    {
        throw new NotImplementedException();
    }
}
