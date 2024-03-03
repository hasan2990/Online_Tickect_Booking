using Microsoft.AspNetCore.Mvc;
using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Services.Interfaces;


namespace Online_Ticket_Booking.Controllers
{

    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _iLoginService;
        private readonly IRegistrationService _iRegistrationService;

        public AuthController(ILoginService iLoginService, IRegistrationService iRegistrationService)
        {
            _iLoginService = iLoginService;
            _iRegistrationService = iRegistrationService;
        }

        [HttpPost]
        [Route("api/registration")]
        public string Registration(RegistrationModel registration)
        {
            return _iRegistrationService.ServiceRegisterUser(registration);             
        }

        [HttpPost]
        [Route("api/login")]
        public IActionResult Login(LoginModel login)
        {
            var token = _iLoginService.ServiceLoginUser(login.Email, login.Password);

            if (!string.IsNullOrEmpty(token))
            {
                return Ok(new { Token = token, Message = "Token generated successfully." });
            }
            else
            {
                return BadRequest("Not Found");
            }
        }
    }
}
