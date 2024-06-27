using Application.Abstractions.Factories.Admin;
using Application.Admin.Commands;
using Application.Admin.Queries;
using Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route(@"admins/")]
public class AdminController(
    IAdminCommandHandlerFactory adminCommandHandlers,
    IAdminQueryHandlerFactory adminQueryHandlers)
    : BaseController
{
    [HttpGet]
    [Route(@"{adminId}")]
    public async Task<IActionResult> ViewAdminDetailsAsync(
        [FromRoute] IdQuery adminId)
    {
        var result = await adminQueryHandlers.AdminDetailViewQueryHandler.HandleAsync(adminId);
        return Ok(result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> ViewAdminListAsync(
        [FromBody] AdminFilterQuery filter)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdminAsync(
        [FromBody] CreateAdminCommand newAdminDetails)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"change-role/")]
    public async Task<IActionResult> ChangeAdminRoleAsync(
        [FromBody] ChangeRoleCommand roleChangeInformation)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"modify-contact/")]
    public async Task<IActionResult> ModifyContactInformationAsync(
        [FromRoute] ModifyContactInformationCommand contactInformationToChange)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route(@"{adminId}")]
    public async Task<IActionResult> DeleteAdminAsync(
        [FromRoute] IdCommand adminId)
    {
        var result = await adminCommandHandlers.DeleteAdminCommandHandler.HandleAsync(adminId);
        return NoContent();
    }
}
