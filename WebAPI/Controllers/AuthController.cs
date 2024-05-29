using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route(@"/auth/")]
public class AuthController : ControllerBase
{
    [HttpPost]
    [Route(@"login/patient/")]
    public Task<IActionResult> PatientLoginAsync([FromBody] object patientLoginData)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route(@"login/admin/")]
    public Task<IActionResult> AdminLoginAsync([FromBody] object adminLoginData)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route(@"login/receptionist/")]
    public Task<IActionResult> ReceptionistLogin([FromBody] object receptionistLoginData)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route(@"login/doctor/")]
    public Task<IActionResult> DoctorLoginAsync([FromBody] object doctorLoginData)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route(@"login/pharmacist/")]
    public Task<IActionResult> PharmacistLoginAsync([FromBody] object pharmacistLoginData)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route(@"login/lab/")]
    public Task<IActionResult> LabWorkerLoginAsync([FromBody] object labWorkerLoginData)
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
