using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Ticket_Booking.Models.Authentication;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Services.Interfaces;


namespace Online_Ticket_Booking.Controllers
{

    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _iLoginService;
        private readonly IRegistrationService _iRegistrationService;

        public AuthController(
            ILoginService iLoginService,
            IRegistrationService iRegistrationService)
        {
            _iLoginService = iLoginService;
            _iRegistrationService = iRegistrationService;
        }

        [HttpPost]
        [Route("api/registration")]
        public async Task<IActionResult> Registration(User registration)
        {
            try
            {
                return Ok(await _iRegistrationService.ServiceRegisterUser(registration));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("api/login")]
        public async Task<IActionResult> Login(Login login)
        {
            bool emailExists = await _iLoginService.CheckEmailExists(login.email);

            if (!emailExists)
            {
                return BadRequest("Invalid Email Id.");
            }

            LoginResponse res = await _iLoginService.ServiceLoginUser(login);
            return Ok(res);
        }
        [HttpGet]
        [Authorize]
        [Route("Authorization")]
        public IActionResult VerifyToken(string email)
        {
            var token = "Authorization";
            return Ok(token);
        }
    }
}
