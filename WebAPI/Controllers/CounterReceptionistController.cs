using Microsoft.AspNetCore.Mvc;

using Services.DataTransferObjects.Common;
using Services.DataTransferObjects.CounterReceptionist;
using Services.DataTransferObjects.LoginAndPasswords;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/counter-receptionist/")]
public class CounterReceptionistController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> CreateCounterReceptionistAsync(
        [FromBody] NewCounterReceptionist createReceptionistData)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> ListCounterReceptionistAsync(
        [FromQuery] Pagination pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{adminId}/")]
    public Task<IActionResult> ViewCounterReceptionistAsync(
        [FromRoute] string receptionistId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    public Task<IActionResult> ModifyCounterReceptionistPassword(
        [FromBody] ChangePasswordInformation passwordChange)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task<IActionResult> DeleteCounterReceptionistAccount(
        [FromRoute] string receptionistId)
    {
        throw new NotImplementedException();
    }
}
