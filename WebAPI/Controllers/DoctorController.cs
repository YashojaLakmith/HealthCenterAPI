using Microsoft.AspNetCore.Mvc;

using WebAPI.DataTransferObjects.Common;
using WebAPI.DataTransferObjects.Doctor;
using WebAPI.DataTransferObjects.LoginAndPasswords;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/doctor/")]
public class DoctorController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> CreateDoctorAsync(
        [FromBody] CreateDoctor doctorCreationParams)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> ListDoctorsAsync(
        [FromBody] DoctorFilterParams? filterParams,
        [FromQuery] Pagination pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{doctorId}/")]
    public Task<IActionResult> GetDoctorInformationAsync(
        [FromRoute] string doctorId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    public Task<IActionResult> ModifyDoctorInformationAsync(
        [FromBody] ModifyDoctorInformation doctorModificationParams)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"change-password/")]
    public Task<IActionResult> ChangeDoctorPasswordAsync(
        [FromBody] ChangePasswordInformation passwordResetParams)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task<IActionResult> DeleteAccountAsync(
        [FromRoute] string accountId)
    {
        throw new NotImplementedException();
    }
}
