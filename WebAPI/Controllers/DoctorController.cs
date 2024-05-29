using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/doctor/")]
public class DoctorController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> CreateDoctorAsync([FromBody] object doctorCreationParams)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> ListDoctorsAsync([FromBody] object filterParams, [FromQuery] object pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{doctorId}/")]
    public Task<IActionResult> GetDoctorInformationAsync([FromRoute] string doctorId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    public Task<IActionResult> ModifyDoctorInformationAsync([FromBody] object doctorModificationParams)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"change-password/")]
    public Task<IActionResult> ChangeDoctorPasswordAsync([FromBody] object passwordResetParams)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task<IActionResult> DeleteAccountAsync([FromRoute] string accountId)
    {
        throw new NotImplementedException();
    }
}
