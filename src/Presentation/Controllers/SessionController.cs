using Application.Abstractions.Factories.Session;
using Application.Common;
using Application.Session.Commands;
using Application.Session.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route(@"session/")]
public class SessionController(
    ISessionCommandHandlerFactory commandHandler,
    ISessionQueryHandlerFactory queryHandlers)
    : BaseController
{
    private readonly ISessionCommandHandlerFactory _commandHandler = commandHandler;
    private readonly ISessionQueryHandlerFactory _queryHandlers = queryHandlers;

    [HttpGet]
    [Route(@"{sessionId}/")]
    public async Task<IActionResult> ViewSessionDetailsAsync(
        [FromRoute] IdQuery sessionId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"by-doctor/")]
    public async Task<IActionResult> ListSessionsByDoctorAsync(
        [FromBody] SessionFilterByDoctorIdQuery filter)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet]
    public async Task<IActionResult> ListAllSessionsAsync(
        [FromBody] SessionFilterQuery filter)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> CreateSessionAsync(
        [FromBody] CreateSessionCommand newSessionInformation)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    public async Task<IActionResult> ModifySessionTimesAsync(
        [FromBody] ModifySessionTimeCommand newSessionTimes)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route(@"{sessionId}/")]
    public async Task<IActionResult> DeleteSessionAsync(
        [FromRoute] IdCommand sessionId)
    {
        throw new NotImplementedException();
    }
}
