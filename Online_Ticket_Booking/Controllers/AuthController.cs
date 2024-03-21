using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
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
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            ILoginService iLoginService, 
            IRegistrationService iRegistrationService,
            ILogger<AuthController> logger)
        {
            _iLoginService = iLoginService;
            _iRegistrationService = iRegistrationService;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/registration")]
        public async Task<IActionResult> Registration(User registration)
        {
            _logger.LogInformation($"Registration API Calling in Controller...{JsonConvert.SerializeObject(registration)}");
            try
            {
                return Ok(await _iRegistrationService.ServiceRegisterUser(registration));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Registration API Error Occur : Message {ex.Message}");
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

            var token = await _iLoginService.ServiceLoginUser(login.email, login.password);
            return Ok(token);
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
