using Application.Abstractions.Factories.Admin;
using Application.Admin.Commands;
using Application.Admin.Queries;
using Application.Admin.Views;
using Application.Common;
using Domain.Common;
using Domain.Enum;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.DataTransferObjects.Common;
using Presentation.Utilities;

namespace Presentation.Controllers;

[NestedRoute<AdminController>(@"admin/")]
public class AdminController(
    IAdminCommandHandlerFactory commandHandlers,
    IAdminQueryHandlerFactory queryHandlers,
    ILogger<AdminController> logger)
    : BaseController(logger)
{
    [HttpGet]
    [Route(@"{adminId:guid}")]
    [ProducesResponseType(typeof(AdminDetailView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ViewAdminDetailsAsync(
        [FromRoute] Guid adminId)
    {
        return await HandleActionAsync(async () =>
        {
            var query = new IdQuery(adminId);
            var result = await queryHandlers.AdminDetailViewQueryHandler.HandleAsync(query);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return result.Error == RepositoryErrors.NotFoundError
                ? NotFound(result.Error)
                : BadRequest(result.Error);
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<AdminListItem>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ViewAdminListAsync(
        [FromBody] AdminFilterQuery filter)
    {
        return await HandleActionAsync(async () =>
        {
            var result = await queryHandlers.AdminListViewQueryHandler.HandleAsync(filter);
            return result.IsFailure
                ? BadRequest(result.Error)
                : Ok(result.Value);
        });
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAdminAsync(
        [FromBody] CreateAdminCommand newAdminDetails)
    {
        return await HandleActionAsync(async () =>
        {
            var result = await commandHandlers.CreateAdminCommandHandler.HandleAsync(newAdminDetails);
            return result.IsFailure
                ? BadRequest(result.Error)
                : StatusCode(StatusCodes.Status201Created);
        });
    }

    [HttpPatch]
    [Route(@"{adminId:guid}/change-role/{newRole}/")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ChangeAdminRoleAsync(
        [FromRoute] Guid adminId,
        [FromRoute] Role newRole)
    {
        return await HandleActionAsync(async () =>
        {
            var command = new ChangeRoleCommand(adminId, newRole);
            var result = await commandHandlers.ChangeRoleCommandHandler.HandleAsync(command);

            return result.IsFailure
                ? BadRequest(result.Error)
                : NoContent();
        });
    }

    [HttpPatch]
    [Route(@"{adminId:guid}modify-contact/")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ModifyContactInformationAsync(
        [FromRoute] Guid adminId,
        [FromBody] ContactDetails newContactDetails)
    {
        return await HandleActionAsync(async () =>
        {
            var command =
                new ModifyContactInformationCommand(adminId, newContactDetails.EmailAddress,
                    newContactDetails.PhoneNumber);
            var changeResult = await commandHandlers.ModifyContactInformationCommandHandler.HandleAsync(command);

            return changeResult.IsFailure
                ? BadRequest(changeResult.Error)
                : NoContent();
        });
    }

    [HttpDelete]
    [Route(@"{adminId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAdminAsync(
        [FromRoute] Guid adminId)
    {
        return await HandleActionAsync(async () =>
        {
            var command = new IdCommand(adminId);
            var result = await commandHandlers.DeleteAdminCommandHandler.HandleAsync(command);

            if (result.IsSuccess)
            {
                return NoContent();
            }

            return result.Error == RepositoryErrors.NotFoundError
                ? NotFound(result.Error)
                : BadRequest(result.Error);
        });
    }
}
