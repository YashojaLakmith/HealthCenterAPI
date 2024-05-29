using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/sys-admin/")]
public class SystemAdminController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> CreateSystemAdminAsync([FromBody] object createAdminData)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> ListSystemAdminsAsync([FromQuery] object pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{adminId}/")]
    public Task<IActionResult> ViewSystemAdminAsync([FromRoute] string adminId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    public Task<IActionResult> ModifySystemAdminPassword([FromBody] object passwordChangeData)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task<IActionResult> DeleteSystemAdminAccount([FromRoute] string adminId)
    {
        throw new NotImplementedException();
    }
}
