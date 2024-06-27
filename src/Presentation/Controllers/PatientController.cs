using Application.Abstractions.Factories.Patient;
using Application.Common;
using Application.Patient.Commands;
using Application.Patient.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route(@"patient/")]
public class PatientController(
    IPatientCommandHandlerFactory commandHandlers,
    IPatientQueryHandlerFactory queryHandlers)
    : BaseController
{
    private readonly IPatientCommandHandlerFactory _commandHandlers = commandHandlers;
    private readonly IPatientQueryHandlerFactory _queryHandlers = queryHandlers;

    [HttpGet]
    public async Task<IActionResult> ViewPatientListAsync(
        [FromBody] PatientFilterQuery filter)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"id/{patientId}/")]
    public async Task<IActionResult> ViewPatientDetailsByIdAsync(
        [FromRoute] IdQuery patientId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"nic/{patientNic}/")]
    public async Task<IActionResult> ViewPatientDetailsByNicAsync(
        [FromRoute] NICQuery patientNic)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatientAsync(
        [FromBody] CreatePatientCommand newPatientInformation)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    public async Task<IActionResult> ModifyPatientContactDetailsAsync(
        [FromBody] ModifyContactInformationCommand contactInformationToChange)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route(@"{patientId}")]
    public async Task<IActionResult> DeletePatientAsync(
        [FromRoute] IdCommand patientId)
    {
        throw new NotImplementedException();
    }
}
