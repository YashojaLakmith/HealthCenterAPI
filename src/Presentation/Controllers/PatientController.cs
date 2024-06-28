using Application.Abstractions.Factories.Patient;
using Application.Common;
using Application.Patient.Commands;
using Application.Patient.Queries;
using Application.Patient.Views;
using Domain.Common;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.DataTransferObjects.Common;
using Presentation.Utilities;

namespace Presentation.Controllers;

[NestedRoute<PatientController>(@"patient/")]
public class PatientController(
    IPatientCommandHandlerFactory commandHandlers,
    IPatientQueryHandlerFactory queryHandlers,
    ILogger<PatientController> logger)
    : BaseController(logger)
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<PatientListItemView>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ViewPatientListAsync(
        [FromBody] PatientFilterQuery filter)
    {
        return await HandleActionAsync(async () =>
        {
            var result = await queryHandlers.PatientListViewQueryHandler.HandleAsync(filter);
            return result.IsFailure
                ? BadRequest(result.Error)
                : Ok(result.Value);
        });
    }

    [HttpGet]
    [Route(@"{patientId:guid}/")]
    [ProducesResponseType(typeof(PatientDetailView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ViewPatientDetailsByIdAsync(
        [FromRoute] Guid patientId)
    {
        return await HandleActionAsync(async () =>
        {
            var result = 
                await queryHandlers.PatientDetailViewByIdQueryHandler.HandleAsync(new IdQuery(patientId));
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
    [Route(@"nic/{patientNic}/")]
    [ProducesResponseType(typeof(PatientDetailView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ViewPatientDetailsByNicAsync(
        [FromRoute] NICQuery patientNic)
    {
        return await HandleActionAsync(async () =>
        {
            var result = 
                await queryHandlers.PatientDetailViewByNicQueryHandler.HandleAsync(patientNic);
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
    public async Task<IActionResult> CreatePatientAsync(
        [FromBody] CreatePatientCommand newPatientInformation)
    {
        return await HandleActionAsync(async () =>
        {
            var result = await commandHandlers.CreatePatientCommandHandler.HandleAsync(newPatientInformation);
            return result.IsFailure
                ? BadRequest(result.Error)
                : StatusCode(StatusCodes.Status201Created);
        });
    }

    [HttpPatch]
    [Route(@"{patientId:guid}/change-contact/")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ModifyPatientContactDetailsAsync(
        [FromRoute] Guid patientId,
        [FromBody] ContactDetails contactInformationToChange)
    {
        var command = new ModifyContactInformationCommand(
            patientId,
            contactInformationToChange.PhoneNumber,
            contactInformationToChange.EmailAddress);

        return await HandleActionAsync(async () =>
        {
            var result = await commandHandlers.ModifyPatientContactInformationCommandHandler.HandleAsync(command);
            return result.IsFailure
                ? NoContent()
                : BadRequest(result.Error);
        });
    }

    [HttpDelete]
    [Route(@"{patientId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeletePatientAsync(
        [FromRoute] Guid patientId)
    {
        return await HandleActionAsync(async () =>
        {
            var result = await commandHandlers.DeletePatientCommandHandler.HandleAsync(new IdCommand(patientId));
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
