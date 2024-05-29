using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/medicine/")]
public class MedicineController : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> SearchMedicineAsync([FromBody] object filters, [FromQuery] object pagination)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{medicineId}/")]
    public Task<IActionResult> ViewMedicineAsync([FromRoute] string medicineId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{userId}/{prescriptionId}/")]
    public Task<IActionResult> IssueMedicineAsync([FromRoute] string userId, [FromRoute] string prescriptionId)
    {
        throw new NotImplementedException();
    }
}
