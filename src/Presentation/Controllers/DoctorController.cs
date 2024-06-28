using Application.Abstractions.Factories.Doctor;
using Application.Common;
using Application.Doctor.Commands;
using Application.Doctor.Queries;
using Application.Doctor.Views;
using Domain.Common;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.DataTransferObjects.Common;
using Presentation.DataTransferObjects.Doctor;
using Presentation.Utilities;

namespace Presentation.Controllers;

[NestedRoute<DoctorController>(@"doctor/")]
public class DoctorController(
    IDoctorCommandHandlerFactory commandHandlers,
    IDoctorQueryHandlerFactory queryHandlers,
    ILogger<DoctorController> logger)
    : BaseController(logger)
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<DoctorListItem>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ListDoctorsAsync(
        [FromBody] FilterDoctorQuery filter)
    {
        return await HandleActionAsync(async () =>
        {
            var result = await queryHandlers.DoctorListViewQueryHandler.HandleAsync(filter);
            return result.IsFailure
                ? BadRequest(result.Error)
                : Ok(result.Value);
        });
    }

    [HttpGet]
    [Route(@"{doctorId:guid}/internal/")]
    [ProducesResponseType(typeof(DoctorDetailViewInternal), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ViewDoctorInternalDetailsAsync(
        [FromRoute] Guid doctorId)
    {
        return await HandleActionAsync(async () =>
        {
            var result =
                await queryHandlers.DoctorInternalDetailViewQueryHandler.HandleAsync(new IdQuery(doctorId));
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
    [Route(@"{doctorId:guid}/public/")]
    [ProducesResponseType(typeof(DoctorDetailViewPublic), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ViewDoctorPublicDetailsAsync(
        [FromRoute] Guid doctorId)
    {
        return await HandleActionAsync(async () =>
        {
            var result =
                await queryHandlers.DoctorPublicDetailViewQueryHandler.HandleAsync(new IdQuery(doctorId));
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return result.Error == RepositoryErrors.NotFoundError
                ? NotFound(result.Error)
                : BadRequest(result.Error);
        });
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateDoctorAsync(
        [FromBody] CreateDoctorCommand newDoctorInformation)
    {
        return await HandleActionAsync(async () =>
        {
            var result = await commandHandlers.CreateDoctorCommandHandler.HandleAsync(newDoctorInformation);
            return result.IsFailure
                ? BadRequest(result.Error)
                : StatusCode(StatusCodes.Status201Created);
        });
    }

    [HttpPatch]
    [Route(@"{doctorId:guid}/modify-contacts/")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ModifyDoctorContactDetailsAsync(
        [FromServices] Guid doctorId,
        [FromBody] ContactDetails contactInformationToModify)
    {
        var command = new ModifyContactInformationCommand(
            doctorId,
            contactInformationToModify.PhoneNumber,
            contactInformationToModify.EmailAddress);

        return await HandleActionAsync(async () =>
        {
            var result = await commandHandlers.ModifyContactInformationCommandHandler.HandleAsync(command);
            return result.IsFailure
                ? BadRequest(result.Error)
                : NoContent();
        });
    }

    [HttpPatch]
    [Route(@"{doctorId:guid}/modify-description/")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ModifyDoctorDescriptionAsync(
        [FromRoute] Guid doctorId,
        [FromBody] Description newDescription)
    {
        var command = new ModifyDescriptionCommand(doctorId, newDescription.NewDescription);

        return await HandleActionAsync(async () =>
        {
            var result = await commandHandlers.ModifyDescriptionCommandHandler.HandleAsync(command);
            if (result.IsSuccess)
            {
                return NoContent();
            }

            return result.Error == RepositoryErrors.NotFoundError
                ? NotFound(result.Error)
                : BadRequest(result.Error);
        });
    }

    [HttpDelete]
    [Route(@"{doctorId:guid}/")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteDoctorAsync(
        [FromRoute] Guid doctorId)
    {
        return await HandleActionAsync(async () =>
        {
            var result = await commandHandlers.DeleteDoctorCommandHandler.HandleAsync(new IdCommand(doctorId));
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
