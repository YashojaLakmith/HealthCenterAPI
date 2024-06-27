using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Factories.Doctor;
using Application.Common;
using Application.Doctor.Commands;
using Application.Doctor.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route(@"/doctors/")]
public class DoctorController(
    IDoctorCommandHandlerFactory commandHandlers,
    IDoctorQueryHandlerFactory queryHandlers)
    : BaseController
{
    private readonly IDoctorCommandHandlerFactory _commandHandlers = commandHandlers;
    private readonly IDoctorQueryHandlerFactory _queryHandlers = queryHandlers;

    [HttpGet]
    public async Task<IActionResult> ListDoctorsAsync(
        [FromBody] FilterDoctorQuery filter)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{doctorId}/internal/")]
    public async Task<IActionResult> ViewDoctorInternalDetailsAsync(
        [FromRoute] IdQuery doctorId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"{doctorId}/public/")]
    public async Task<IActionResult> ViewDoctorPublicDetailsAsync(
        [FromRoute] IdQuery doctorId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> CreateDoctorAsync(
        [FromBody] CreateDoctorCommand newDoctorInformation)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"contacts/")]
    public async Task<IActionResult> ModifyDoctorContactDetailsAsync(
        [FromBody] ModifyContactInformationCommand contactInformationToModify)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route(@"description/")]
    public async Task<IActionResult> ModifyDoctorDescriptionAsync(
        [FromBody] ModifyDescriptionCommand newDescription)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route(@"{doctorId}/")]
    public async Task<IActionResult> DeleteDoctorAsync(
        [FromRoute] IdCommand doctorId)
    {
        throw new NotImplementedException();
    }
}
