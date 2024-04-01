using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Ticket_Booking.Middleware;
using Online_Ticket_Booking.Models.Authentication;
using Online_Ticket_Booking.Services.Interfaces;

namespace Online_Ticket_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginWithRefreshTokenController : ControllerBase
    {
        private readonly CustomAuth _tokenService;
        private readonly ILoginServiceWithRefreshToken _loginService;
        private readonly IRegistrationService _iRegistrationService;

        public LoginWithRefreshTokenController
        (
            CustomAuth tokenService,
            ILoginServiceWithRefreshToken loginService,
            IRegistrationService iRegistrationService

        )
        {
            _tokenService = tokenService;
            _loginService = loginService;
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
        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel user)
        {
            IActionResult response = Unauthorized();

            return Ok(await _loginService.GetUserLoginInfo(user));
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokens([FromBody] UserLoginModel user)
        {

            string refreshToken = user.refreshToken;
            string email = user.email;


            string extractedemail = await _tokenService.ExtractUserIdFromRefreshToken(refreshToken);


            if (email != extractedemail)
            {
                return BadRequest("User ID mismatch");
            }


            var tokenResponse = await _tokenService.GenerateToken(user.email);

            return Ok(tokenResponse);
        }
    }
}
