using Microsoft.AspNetCore.Mvc;

using Services.DataTransferObjects.Common;
using Services.DataTransferObjects.LoginAndPasswords;
using Services.DataTransferObjects.SystemAdmin;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/sys-admin/")]
public class SystemAdminController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> CreateSystemAdminAsync(
        [FromBody] CreateSystemAdmin createAdminData)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> ListSystemAdminsAsync(
        [FromBody] SystemAdminFilter filter,
        [FromQuery] Pagination pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{adminId}/")]
    public Task<IActionResult> ViewSystemAdminAsync(
        [FromRoute] string adminId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    public Task<IActionResult> ModifySystemAdminPassword(
        [FromBody] ChangePasswordInformation passwordChangeData)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task<IActionResult> DeleteSystemAdminAccount(
        [FromRoute] string adminId)
    {
        throw new NotImplementedException();
    }
}
