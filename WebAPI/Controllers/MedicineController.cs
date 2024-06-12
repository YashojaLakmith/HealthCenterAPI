using Microsoft.AspNetCore.Mvc;

using WebAPI.DataTransferObjects.Common;
using WebAPI.DataTransferObjects.Medicine;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/medicine/")]
public class MedicineController : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> SearchMedicineAsync(
        [FromBody] MedicineFilter filters,
        [FromQuery] Pagination pagination)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<IActionResult> CreateMedicineAsync(
        [FromBody] NewMedicine newMedicine)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{medicineId}/")]
    public Task<IActionResult> ViewMedicineAsync(
        [FromRoute] string medicineId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task<IActionResult> DeleteMedicineAsync(
        [FromRoute] string medicineId)
    {
        throw new NotImplementedException();
    }
}
