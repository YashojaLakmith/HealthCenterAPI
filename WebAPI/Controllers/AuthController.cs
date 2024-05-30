using Microsoft.AspNetCore.Mvc;

using Services.DataTransferObjects.Login;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/auth/")]
public class AuthController : ControllerBase
{
    [HttpPost]
    [Route(@"login/patient/")]
    public Task<IActionResult> PatientLoginAsync(
        [FromBody] LoginInformation patientLoginData)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route(@"login/admin/")]
    public Task<IActionResult> AdminLoginAsync(
        [FromBody] LoginInformation adminLoginData)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route(@"login/receptionist/")]
    public Task<IActionResult> ReceptionistLogin(
        [FromBody] LoginInformation receptionistLoginData)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route(@"login/doctor/")]
    public Task<IActionResult> DoctorLoginAsync(
        [FromBody] LoginInformation doctorLoginData)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route(@"login/pharmacist/")]
    public Task<IActionResult> PharmacistLoginAsync(
        [FromBody] LoginInformation pharmacistLoginData)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route(@"login/lab/")]
    public Task<IActionResult> LabWorkerLoginAsync(
        [FromBody] LoginInformation labWorkerLoginData)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route(@"logout")]
    public Task<IActionResult> LogoutAsync()
    {
        throw new NotImplementedException();
    }
}
