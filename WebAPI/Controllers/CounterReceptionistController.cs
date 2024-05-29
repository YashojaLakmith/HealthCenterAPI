using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/counter-receptionist/")]
public class CounterReceptionistController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> CreateCounterReceptionistAsync([FromBody] object createReceptionistData)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> ListCounterReceptionistAsync([FromQuery] object pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{adminId}/")]
    public Task<IActionResult> ViewCounterReceptionistAsync([FromRoute] string receptionistId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    public Task<IActionResult> ModifyCounterReceptionistPassword([FromBody] object passwordChangeData)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task<IActionResult> DeleteCounterReceptionistAccount([FromRoute] string receptionistId)
    {
        throw new NotImplementedException();
    }
}
