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
        public async Task<string> Registration(User registration)
        {
            return await _iRegistrationService.ServiceRegisterUser(registration);             
        }

        [HttpPost]
        [Route("api/login")]
        public async Task<IActionResult> Login(Login login)
        {
            bool emailExists = await _iLoginService.CheckEmailExists(login.email);

            if (!emailExists)
            {         
                return BadRequest("Invalid email.");
            }

            var token = await _iLoginService.ServiceLoginUser(login.email, login.password);

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
